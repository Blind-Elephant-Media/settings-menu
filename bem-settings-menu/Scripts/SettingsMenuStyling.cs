using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace bem_settings_menu.Scripts
{
    public class SettingsMenuStyling : MonoBehaviour
    {
        [Header("Settings Menu Styling")]
        [SerializeField] private Color backgroundColor = Color.white;
        [Header("Sounds")]
        [SerializeField] private AudioClip hoverSound;
        [SerializeField] private AudioClip clickSound;
        
        [Header("References")]
        [SerializeField] private Image backgroundImage;
        [SerializeField] private AudioSource audioSource;
       private static SettingsMenuStyling _instance;

       private void Awake()
       {
           _instance = this;
       }

       private void Start()
       {
           ApplyStyling();
       }
    
       [ContextMenu("Apply Styling")]
       private void ApplyStyling()
       {
           backgroundImage.color = backgroundColor;
       }
       
       /// <summary>
       /// Plays a random pitch of the hover sound
       /// </summary>
       public static void PlayHoverSound()
       {
           _instance.audioSource.clip = _instance.hoverSound;
           _instance.audioSource.pitch = Random.Range(0.9f, 1.1f);
           _instance.audioSource.Play();
       }

       /// <summary>
       /// Plays a random pitch of the click sound
       /// </summary>
       public static void PlayClickSound()
       {
           _instance.audioSource.clip = _instance.clickSound;
           _instance.audioSource.pitch = Random.Range(0.9f, 1.1f);
           _instance.audioSource.Play();
       }
    }
}
