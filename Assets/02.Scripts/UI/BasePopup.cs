using UnityEngine;

namespace Imnyeong
{
    public class BasePopup : MonoBehaviour
    {
        public virtual PopupType popupType { get; }

        public void ShowPopup(PopupType _popupType)
        {
            this.gameObject.SetActive(popupType == _popupType);
        }
        public void HidePopup()
        {
            this.gameObject.SetActive(false);
        }
    }
}
