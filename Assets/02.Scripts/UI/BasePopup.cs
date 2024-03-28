using UnityEngine;

namespace Imnyeong
{
    public class BasePopup : MonoBehaviour
    {
        public virtual PopupType popupType { get; }
        public GameObject panel;

        public void ShowPopup()
        {
            panel.SetActive(true);
            this.gameObject.SetActive(true);
        }
        public void HidePopup()
        {
            panel.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
