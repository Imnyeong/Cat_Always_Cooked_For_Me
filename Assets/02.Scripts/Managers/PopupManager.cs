using System.Collections.Generic;
using UnityEngine;

namespace Imnyeong
{
    public class PopupManager : MonoBehaviour
    {
        public List<BasePopup> popups;

        public void ShowPopup(PopupType _popupType)
        {
            popups.Find(x => x.popupType == _popupType).ShowPopup();
        }
        public void HidePopup(PopupType _popupType)
        {
            popups.Find(x => x.popupType == _popupType).HidePopup();
        }

        public void ShowCatInfoPopup(Cat _cat)
        {            
            CatInfoPopup catInfo = popups.Find(x => x.popupType == PopupType.CatInfo).GetComponent<CatInfoPopup>();
            catInfo.ShowPopup();
            catInfo.SetCatInfoPopup(_cat);
        }
    }
}
