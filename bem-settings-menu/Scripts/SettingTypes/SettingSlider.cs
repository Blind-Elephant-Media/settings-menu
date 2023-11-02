using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace bem_settings_menu.Scripts.SettingTypes
{
    public class SettingSlider : MonoBehaviour
    {
        public Slider slider;
        public TextMeshProUGUI valueText;

        private PageData.SettingData _setting;
        
        private int _value;
        private void Start()
        {
            OnValueChange();
        }

        /// <summary>
        /// Called when the slider value changes
        /// </summary>
        public void OnValueChange()
        {
            int newValue = (int)slider.value;
            newValue = (int)Mathf.Round(newValue / _setting.sliderStepValue) * (int)_setting.sliderStepValue;
            if (Math.Abs(newValue - _value) > _setting.sliderStepValue / 2f)
            {
                _value = newValue;
            }
            
            valueText.text = _value.ToString("F0");
            SettingsMenuManager.UpdateSetting(_setting.settingId, _value);
        }

        /// <summary>
        /// Initialize the setting
        /// </summary>
        /// <param name="setting"></param>
        /// <param name="savedValue"></param>
        public void Initialize(PageData.SettingData setting, int savedValue)
        {
            _setting = setting;
            slider.minValue = setting.sliderMinValue;
            slider.maxValue = setting.sliderMaxValue;
            slider.value = savedValue == -1 ? setting.sliderDefaultValue : savedValue;
            slider.wholeNumbers = true;
            OnValueChange();
        }
    }
}