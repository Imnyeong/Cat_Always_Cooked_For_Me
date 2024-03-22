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

		private Image foodThmbnail;
		private string foodName;
		private int foodCount;

		public void UpdateItem(Food _food)
		{
			foodThmbnail = _food.food.thumbnail;
			foodName = _food.food.foodName;
			foodCount = _food.count;

			sellButton.onClick.RemoveAllListeners();
			sellButton.onClick.AddListener(delegate { SellFood(_food.food, 0); });

			SetItem(foodThmbnail, foodName, foodCount);
		}

		public void SetItem(Image _image, string _name, int _count)
        {
			thumbnail = _image;
			nameText.text = _name;
			countText.text = _count.ToString();
		}

		public void SellFood(FoodData _food, int _count)
        {
			GameManager.instance.SellFood(_food, _count);
			GameManager.instance.GetMoney(_food.price * _count);
        }
	}
}