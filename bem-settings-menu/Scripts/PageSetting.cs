using System;
using bem_settings_menu.Scripts.SettingTypes;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace bem_settings_menu.Scripts
{
    public class PageSetting : MonoBehaviour, IPointerEnterHandler
    {
        [SerializeField] private TextMeshProUGUI textTitle;
        [SerializeField] private TextMeshProUGUI headerTitle;
        [Header("References")]
        [SerializeField] private SettingSlider settingSlider;
        [SerializeField] private MultiChoice multiChoice;
        [Space]
        [SerializeField] private GameObject background;

        private PageData.SettingData _setting;
        /// <summary>
        /// Initialize the setting
        /// </summary>
        /// <param name="setting">Setting to init</param>
        /// <param name="savedValue">If a saved value exist apply it (if not set as -1)</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Initialize(PageData.SettingData setting, int savedValue)
        {
            textTitle.text = setting.settingName;
            headerTitle.text = setting.settingName;

            //Activate all the settings
            background.SetActive(true);
            textTitle.gameObject.SetActive(true);
            headerTitle.gameObject.SetActive(true);
            settingSlider.gameObject.SetActive(false);
            multiChoice.gameObject.SetActive(false);
            
            switch (setting.settingType)
            {
                case PageData.SettingData.SettingTypes.Header:
                    background.SetActive(false);
                    textTitle.gameObject.SetActive(false);
                    break;
                case PageData.SettingData.SettingTypes.MultiChoice:
                    headerTitle.gameObject.SetActive(false);
                    multiChoice.gameObject.SetActive(true);
                    multiChoice.Initialize(setting, savedValue);
                    break;
                case PageData.SettingData.SettingTypes.Slider:
                    headerTitle.gameObject.SetActive(false);
                    settingSlider.gameObject.SetActive(true);
                    settingSlider.Initialize(setting, savedValue);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            _setting = setting;
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            if(_setting.settingType != PageData.SettingData.SettingTypes.Header)
                SettingsMenuManager.SetInfoText(_setting.settingDescription);
        }
    }
}