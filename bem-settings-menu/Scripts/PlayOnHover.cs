using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace bem_settings_menu.Scripts
{
    public class PlayOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        private bool _isHovering = false;
        public void OnPointerEnter(PointerEventData eventData)
        {
            _isHovering = true;
            SettingsMenuStyling.PlayHoverSound();
        }
        
        public void OnPointerExit(PointerEventData eventData)
        {
            _isHovering = false;
        }

        private void Update()
        {
            if (_isHovering && Input.GetKeyDown(KeyCode.Mouse0))
            {
                SettingsMenuStyling.PlayClickSound();
            }
        }
    }
}