using System;
using TMPro;
using UnityEngine;

namespace bem_settings_menu.Scripts
{
    public class ScaleAfterText : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private ScaleTypes scaleType = ScaleTypes.Both;
        [SerializeField] private Vector2 padding = new Vector2(10, 10);
        
        private enum ScaleTypes
        {
            Horizontal,
            Vertical,
            Both
        }
     

        private void Start()
        {
            UpdateScale();
        }

        /// <summary>
        /// Updates the scale of the RectTransform to fit the text
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        [ContextMenu("Update Scale")]
        public void UpdateScale()
        {
            float sizeX = text.preferredWidth + padding.x * 2f;
            float sizeY = text.preferredHeight + padding.y * 2f;
            
            switch (scaleType)
            {
                case ScaleTypes.Horizontal:
                    rectTransform.sizeDelta = new Vector2(sizeX, rectTransform.sizeDelta.y);
                    break;
                case ScaleTypes.Vertical:
                    rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, sizeY);
                    break;
                case ScaleTypes.Both:
                    rectTransform.sizeDelta = new Vector2(sizeX, sizeY);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
