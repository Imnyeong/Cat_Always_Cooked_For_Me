using UnityEngine;
using UnityEngine.UI;

namespace Imnyeong
{
    public class SellItem : MonoBehaviour
    {
		[SerializeField]
		private Image thumbnail;
		[SerializeField]
		private Text nameText;
		[SerializeField]
		private Text countText;
		[SerializeField]
		private Button sellButton;
		[SerializeField]
		private Text sellText;

		public void UpdateItem(Food _food)
		{
			sellButton.onClick.RemoveAllListeners();
			sellButton.onClick.AddListener(delegate { SellFood(_food, 1); });

			SetItem(_food.food.thumbnail, _food.food.foodName, _food.count);
		}

		public void SetItem(Sprite _image, string _name, int _count)
        {
			thumbnail.sprite = _image;
			nameText.text = _name;
			countText.text = _count.ToString();
			sellButton.interactable = _count != 0;
			sellText.text = sellButton.interactable ? "판매" : "재고 소진";
		}
		public void SellFood(Food _food, int _count)
        {
            GameManager.instance.SellFood(_food.food, _count);
			SetItem(_food.food.thumbnail, _food.food.foodName, _food.count);
        }
    }
}