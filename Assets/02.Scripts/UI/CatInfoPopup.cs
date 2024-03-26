using UnityEngine;

namespace Imnyeong
{
    public class CatInfoPopup : BasePopup
    {
        public override PopupType popupType => PopupType.CatInfo;

        private Cat cat;

        public void ShowCatInfoPopup(Cat _cat)
        {
            cat = _cat;
        }
    }
}
