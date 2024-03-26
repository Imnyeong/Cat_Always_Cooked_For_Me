using UnityEngine;

namespace Imnyeong
{
    public class BasePopup : MonoBehaviour
    {
        public virtual PopupType popupType { get; }

        public void ShowPopup()
        {
            this.gameObject.SetActive(true);
        }
        public void HidePopup()
        {
            this.gameObject.SetActive(false);
        }
    }
}
