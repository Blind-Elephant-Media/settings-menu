using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace bem_settings_menu.Scripts.SettingTypes
{
    public class MultiChoice : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI selectedText;
        [SerializeField, ColorUsage(true, false)] private Color selectedColor;
        [SerializeField, ColorUsage(true, false)] private Color unselectedColor;
        [Header("References")]
        [SerializeField] private Image indexObject;
        [SerializeField] private Transform indexParent;
        private Image[] _indexObjects;
        private PageData.SettingData _setting;
        private int _index;
        /// <summary>
        /// Initialize the setting
        /// </summary>
        /// <param name="setting"></param>
        /// <param name="savedValue"></param>
        public void Initialize(PageData.SettingData setting, int savedValue)
        {
            if (_indexObjects == null)
            {
                _indexObjects = new Image[setting.multiChoiceOptions.Length];
                for (var index = 0; index < setting.multiChoiceOptions.Length; index++)
                {
                    Image createdObject = Instantiate(indexObject, indexParent);
                    _indexObjects[index] = createdObject;
                }
            }
            _index = savedValue == -1 ? setting.multiChoiceDefaultValue : savedValue;
            _setting = setting;
            
            UpdateIndex(_index);
        }
        
        private void UpdateIndex(int index)
        {
            for (var i = 0; i < _indexObjects.Length; i++)
            {
                _indexObjects[i].color = i == index ? selectedColor : unselectedColor;
            }
            selectedText.text = _setting.multiChoiceOptions[index].optionName;
            
            _index = index;
            
            SettingsMenuManager.UpdateSetting(_setting.settingId, _index);
        }

        public void Next()
        {
            _index++;
            if(_index >= _setting.multiChoiceOptions.Length)
                _index = 0;
            UpdateIndex(_index);
        }

        public void Last()
        {
            _index--;
            if(_index < 0)
                _index = _setting.multiChoiceOptions.Length - 1;
            UpdateIndex(_index);
        }
    }
}