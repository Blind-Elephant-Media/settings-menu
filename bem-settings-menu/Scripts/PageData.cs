using System;
using UnityEngine;

namespace bem_settings_menu.Scripts
{
    [Serializable]
    public class PageData
    {
        public string pageName;
        [Space]
        public SettingData[] pageSettings;
        
        [HideInInspector]public Page pageInstance;
        [HideInInspector]public NavigationButton navButtonInstance;
        [HideInInspector]public int pageIndex;

        [Serializable]
        public class SettingData
        {
            public string settingName;
            public string settingId;
            public SettingTypes settingType;
            [TextArea] public string settingDescription;
            [Space]
            [Header("Multi Choice")]
            public MultiChoiceOption[] multiChoiceOptions;
            public int multiChoiceDefaultValue;
            [Space]
            [Header("Slider")]
            public float sliderMinValue;
            public float sliderMaxValue;
            [Min(1)]
            public int sliderStepValue = 1;
            public int sliderDefaultValue;
            
            [HideInInspector]public PageSetting settingInstance;
            
            public enum SettingTypes
            {
                Header,
                MultiChoice,
                Slider,
                Keybind,
            }
            
            
            [Serializable]
            public class MultiChoiceOption
            {
                public string optionName;
                public string optionValue;
            }
        }

        /// <summary>
        /// Activate or deactivate the page
        /// </summary>
        /// <param name="active">If true active else deavtive</param>
        public void Active(bool active)
        {
            pageInstance.gameObject.SetActive(active);
            navButtonInstance.Active(active);
        }
        
    }
}