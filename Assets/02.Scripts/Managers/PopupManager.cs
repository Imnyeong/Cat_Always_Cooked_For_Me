using System.Collections.Generic;
using UnityEngine;

namespace Imnyeong
{
    public class PopupManager : MonoBehaviour
    {
        public List<BasePopup> popups;
        public GameObject panel;

        public void ShowPopup(PopupType _popupType)
        {
            panel.SetActive(true);
            popups.Find(x => x.popupType == _popupType).ShowPopup();
        }
        public void HidePopup(PopupType _popupType)
        {
            panel.SetActive(false);
            popups.Find(x => x.popupType == _popupType).HidePopup();
        }

        public void ShowCatInfoPopup(Cat _cat)
        {
            panel.SetActive(true);
            CatInfoPopup catInfo = popups.Find(x => x.popupType == PopupType.CatInfo).GetComponent<CatInfoPopup>();
            catInfo.gameObject.SetActive(true);
            catInfo.ShowCatInfoPopup(_cat);
        }
    }
}
