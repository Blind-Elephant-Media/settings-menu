using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

namespace bem_settings_menu.Scripts
{
    public static class ConfigurationManager
    {
        private static List<SettingObject> _rawFileList;
        
        public class SettingObject
        {
            public string ID;
            public int ValueInt;
            public string ValueString;
        }
        
        /// <summary>
        /// Returns the raw file as a string array
        /// </summary>
        /// <returns></returns>
        public static string[] GetRawFileArray()
        {
            if(!File.Exists(Application.persistentDataPath + "/settings.txt"))
                File.WriteAllText(Application.persistentDataPath + "/settings.txt", "");
                
            string[] lines = File.ReadAllLines(Application.persistentDataPath + "/settings.txt");
            return lines;
        }
        
        public static string GetRawFile()
        {
            string text = File.ReadAllText(Application.persistentDataPath + "/settings.txt");
            return text;
        }

        /// <summary>
        /// Loads the settings file
        /// </summary>
        public static void LoadFileToSettingsObject()
        {
            string[] lines = GetRawFileArray();
            _rawFileList = new List<SettingObject>();
            for (var index = 0; index < lines.Length; index++)
            {
                var setting = lines[index];
                SettingObject settingObject = new SettingObject();
                string[] array = setting.Split(':');
                settingObject.ID = array[0];
                settingObject.ValueInt = int.Parse(array[1], CultureInfo.InvariantCulture.NumberFormat);
                _rawFileList.Add(settingObject);
            }
        }

        /// <summary>
        /// Adds a setting to the settings file
        /// </summary>
        /// <param name="setting"></param>
        public static void AddSetting(PageData.SettingData setting)
        {
            _rawFileList.Add(SettingToSettingObject(setting));
        }

        /// <summary>
        /// Converts the settings file to a string
        /// </summary>
        /// <returns></returns>
        public static string SettingObjectToString()
        {
            string text = "";
            foreach (var setting in _rawFileList)
            {
                text += setting.ID + ":" + setting.ValueInt + "\n";
            }

            return text;
        }

        /// <summary>
        /// Converts a setting to a setting object
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static SettingObject SettingToSettingObject(PageData.SettingData setting)
        {
            SettingObject settingObject = new SettingObject();
            settingObject.ID = setting.settingId;
            
            int intValue = -1;
            if(setting.settingType == PageData.SettingData.SettingTypes.MultiChoice)
                intValue = setting.multiChoiceDefaultValue;
            else if(setting.settingType == PageData.SettingData.SettingTypes.Slider)
                intValue = setting.sliderDefaultValue;
            settingObject.ValueInt = intValue;
            
            string stringValue = "";
            if (setting.settingType == PageData.SettingData.SettingTypes.Keybind)
                stringValue = "";
            settingObject.ValueString = stringValue;
            
            
            return settingObject;
        }

        /// <summary>
        /// Returns the value of the setting with the id
        /// </summary>
        /// <param name="id">The id to grab the int for if not exist return -1</param>
        /// <returns></returns>
        public static int GetInt(string id)
        {
            foreach (var setting in _rawFileList)
            {
                if (id == setting.ID) return setting.ValueInt;
            }
            return -1;
        }
        
        public static string GetString(string id)
        {
            foreach (var setting in _rawFileList)
            {
                if (id == setting.ID) return setting.ValueString;
            }
            return "";
        }
        
        /// <summary>
        /// Returns true if the id exists in the settings file
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool IntExist(string id)
        {
            foreach (var setting in _rawFileList)
            {
                if(id == setting.ID && setting.ValueInt != -1) return true;
            }
            return false;
        }
        
        /// <summary>
        /// Returns true if the id exists in the settings file
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool StringExist(string id)
        {
            foreach (var setting in _rawFileList)
            {
                if(id == setting.ID && !string.IsNullOrEmpty(setting.ValueString)) return true;
            }
            return false;
        }

        /// <summary>
        /// Updates the value of the setting with the id but does not save the file
        /// </summary>
        /// <param name="settingId"></param>
        /// <param name="value"></param>
        public static void UpdateSetting(string settingId, int value)
        {
            foreach (var setting in _rawFileList)
            {
                if (settingId == setting.ID)
                {
                    setting.ValueInt = value;
                    return;
                }
            }
        }
        
        /// <summary>
        /// Updates the value of the setting with the id but does not save the file
        /// </summary>
        /// <param name="settingId"></param>
        /// <param name="value"></param>
        public static void UpdateSetting(string settingId, string value)
        {
            foreach (var setting in _rawFileList)
            {
                if (settingId == setting.ID)
                {
                    setting.ValueString = value;
                    return;
                }
            }
        }

        /// <summary>
        /// Saves the file
        /// </summary>
        public static void SaveFile()
        {
            Debug.Log(_rawFileList.Count);
            File.WriteAllText(Application.persistentDataPath + "/settings.txt", "");
            File.WriteAllText(Application.persistentDataPath + "/settings.txt", SettingObjectToString());
        }

        /// <summary>
        /// Clears the changes made to the settings file
        /// </summary>
        public static void ClearChanges()
        {
            _rawFileList = new List<SettingObject>();
        }
        
        /// <summary>
        /// Clears the settings file
        /// </summary>
        public static void ClearFile()
        {
            File.WriteAllText(Application.persistentDataPath + "/settings.txt", "");
        }
    }
}