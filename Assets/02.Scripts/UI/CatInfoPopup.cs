using UnityEngine;
using UnityEngine.UI;

namespace Imnyeong
{
    public class CatInfoPopup : BasePopup
    {
        public override PopupType popupType => PopupType.CatInfo;

        private Cat cat;
        [SerializeField] private Image thumbnail;
        [SerializeField] private Button closeButton;
        [SerializeField] private Text ingredient;
        [SerializeField] private Text abilityValue;
        [SerializeField] private Text workPoint;

        
        public void SetCatInfoPopup(Cat _cat)
        {
            closeButton.onClick.RemoveAllListeners();
            closeButton.onClick.AddListener(HidePopup);

            cat = _cat; 
            thumbnail.sprite = _cat.thumbnail.sprite;
            ingredient.text = GameManager.instance.gameData.ingredientDatas.Find(x => (x.abilityType == _cat.abilityType) && (x.abilityIndex == _cat.abilityIndex)).ingredientName;
            abilityValue.text = _cat.abilityValue.ToString();
            workPoint.text = _cat.workDelay.ToString();
        }
    }
}
