using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace bem_settings_menu.Scripts
{
    public class SettingsMenuManager : MonoBehaviour
    {
        public PageData[] pages;

        [Header("References")] 
        [SerializeField] private TextMeshProUGUI infoText;
        [SerializeField] private GameObject settingsMenu;
        [SerializeField] private GameObject saveSettings;
        [Space]
        [SerializeField] private Page pagePrefab;
        [SerializeField] private Transform pageContainer;
        [Space]
        [SerializeField] private PageSetting pageSettingPrefab;
        [Space]
        [SerializeField] private NavigationButton navButtonPrefab;
        [SerializeField] private Transform navButtonContainer;

        private int _pageIndex = 0;
        
        private static SettingsMenuManager _instance;
        
        private bool _ready = false;

        private void Awake()
        {
            _instance = this;
        }

        private void Start()
        {
            ConfigurationManager.LoadFileToSettingsObject();
            bool addedSettings = false;
            for (var index = 0; index < pages.Length; index++)
            {
                PageData page = pages[index];
                Page createdPage = Instantiate(pagePrefab, pageContainer);
                createdPage.Initialize(page);
                page.pageInstance = createdPage;

                NavigationButton createdNavButton = Instantiate(navButtonPrefab, navButtonContainer);
                Button.ButtonClickedEvent onClick = new Button.ButtonClickedEvent();
                onClick.AddListener(() => ChangePage(page.pageIndex));
                createdNavButton.Initialize(page, onClick);
                page.navButtonInstance = createdNavButton;

                foreach (PageData.SettingData setting  in page.pageSettings)
                {
                    PageSetting createdSetting = Instantiate(pageSettingPrefab, createdPage.transform);

                    if (setting.settingType != PageData.SettingData.SettingTypes.Header)
                    {
                        if (!ConfigurationManager.IntExist(setting.settingId) && !ConfigurationManager.StringExist(setting.settingId))
                        {
                            ConfigurationManager.AddSetting(setting);
                            createdSetting.Initialize(setting, -1);
                            addedSettings = true;
                        }
                        else
                        {
                            int savedValue = ConfigurationManager.GetInt(setting.settingId);
                            createdSetting.Initialize(setting, savedValue);
                        }
                    }
                    else createdSetting.Initialize(setting, -1);
                    
                    setting.settingInstance = createdSetting;
                    
                }
                
                page.pageIndex = index;
            }

            UpdatePages();
            if (addedSettings) ConfigurationManager.SaveFile();
        }


        /// <summary>
        /// Updates the pages to show the current page
        /// </summary>
        private void UpdatePages()
        {
            foreach (PageData page in pages)
            {
                page.Active(false);
            }
            
            pages[_pageIndex].Active(true);
        }
        
        /// <summary>
        /// Changes the page to the given index
        /// </summary>
        /// <param name="index">The page to change to</param>
        private void ChangePage(int index)
        {
            _pageIndex = index;
            UpdatePages();
            infoText.text = "";
        }

        /// <summary>
        /// Opens the settings menu
        /// </summary>
        private void OpenSettingsMenu()
        {
            settingsMenu.SetActive(true);
        }
        
        /// <summary>
        /// Closes the settings menu
        /// </summary>
        private void CloseSettingsMenu()
        {
            settingsMenu.SetActive(false);
        }

        private void LateUpdate()
        {
            _ready = true;
        }

        #region Static Calls
        /// <summary>
        /// Opens the settings menu
        /// </summary>
        public static void Open()
        {
            _instance.OpenSettingsMenu();
        }
        
        /// <summary>
        /// Closes the settings menu
        /// </summary>
        public static void Close()
        {
            _instance.CloseSettingsMenu();
            
            ConfigurationManager.ClearChanges();
        }

        /// <summary>
        /// Updates the setting with the given id to the given value (Does not check if the given value and id is valid)
        /// </summary>
        /// <param name="settingId">The id of the setting</param>
        /// <param name="value">The value to change</param>
        public static void UpdateSetting(string settingId, int value)
        {
            ConfigurationManager.UpdateSetting(settingId, value);
            if(_instance._ready)
                _instance.saveSettings.SetActive(true);
        }
        
        /// <summary>
        /// Writes the changes to the settings file (Found in the Application.persistentDataPath folder)
        /// </summary>
        public static void SaveSettings()
        {
            ConfigurationManager.SaveFile();
            _instance.saveSettings.SetActive(false);
        }
        
        /// <summary>
        /// Resets the settings file to the default values
        /// </summary>
        public static void ResetSettings()
        {
            Debug.Log("Clear settings file");
            ConfigurationManager.ClearFile();
            
            Debug.Log("Reset stored changes");
            ConfigurationManager.ClearChanges();   
            
            foreach (PageData page in _instance.pages)
            {
                foreach (PageData.SettingData setting in page.pageSettings)
                {
                    if (setting.settingType != PageData.SettingData.SettingTypes.Header)
                    {
                        ConfigurationManager.AddSetting(setting);
                        setting.settingInstance.Initialize(setting, -1);
                    }
                }
            }
            
            ConfigurationManager.SaveFile();
        }
        
        /// <summary>
        /// Sets the info text to the given text
        /// </summary>
        /// <param name="text">The text that will show in the info field</param>
        public static void SetInfoText(string text)
        {
            _instance.infoText.text = text;
        }
        #endregion

        private void OnApplicationQuit()
        {
            ConfigurationManager.ClearChanges();
        }
    }
    
    
}
