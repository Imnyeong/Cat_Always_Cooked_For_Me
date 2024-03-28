using UnityEngine;
using UnityEngine.UI;

namespace Imnyeong
{
    public class CatInfoPopup : BasePopup
    {
        public override PopupType popupType => PopupType.CatInfo;

        //private Cat cat;
        [SerializeField] private Image thumbnail;
        [SerializeField] private Button closeButton;
        [SerializeField] private Text abilityType;
        [SerializeField] private Text abilityValue;
        [SerializeField] private Text workPoint;

        
        public void SetCatInfoPopup(Cat _cat)
        {
            closeButton.onClick.RemoveAllListeners();
            closeButton.onClick.AddListener(HidePopup);

            thumbnail.sprite = _cat.thumbnail.sprite;
            switch(_cat.abilityType)
            {
                case AbilityType.Wood:
                    abilityType.text = "����";
                    break;
                case AbilityType.Rice:
                    abilityType.text = "��";
                    break;
                case AbilityType.Fish:
                    abilityType.text = "�����";
                    break;
            }
            abilityValue.text = _cat.abilityValue.ToString();
            workPoint.text = _cat.workDelay.ToString();
        }
    }
}
