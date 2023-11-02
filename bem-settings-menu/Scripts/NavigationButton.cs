using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace bem_settings_menu.Scripts
{
    public class NavigationButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Button button;
        /// <summary>
        /// Initializes the page
        /// </summary>
        /// <param name="pageData">The page</param>
        /// <param name="onClick">On click event</param>
        public void Initialize(PageData pageData, Button.ButtonClickedEvent onClick)
        {
            transform.name = pageData.pageName;
            text.text = pageData.pageName;
            text.ForceMeshUpdate();
            GetComponent<ScaleAfterText>().UpdateScale();
            button.onClick = onClick;
        }

        /// <summary>
        /// Sets the button as active or not
        /// </summary>
        /// <param name="active">If true active else deactive</param>
        public void Active(bool active)
        {
            button.interactable = !active;
            
            text.color = active ? Color.black : Color.white;
        }
    }
}