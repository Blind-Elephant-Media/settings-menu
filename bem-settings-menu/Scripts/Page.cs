using UnityEngine;

namespace bem_settings_menu.Scripts
{
    public class Page : MonoBehaviour
    {
        /// <summary>
        /// Initializes the page
        /// </summary>
        /// <param name="pageData"></param>
        public void Initialize(PageData pageData)
        {
            transform.name = pageData.pageName;
        }
        
       
    }
}
