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
			sellButton.onClick.AddListener(delegate { SellFood(_food, 1); });

			SetItem(foodThmbnail, foodName, foodCount);
		}

		public void SetItem(Image _image, string _name, int _count)
        {
			thumbnail = _image;
			nameText.text = _name;
			countText.text = _count.ToString();
		}
		public void SellFood(Food _food, int _count)
        {
            GameManager.instance.SellFood(_food.food, _count);
			foodCount = _food.count;

			if (foodCount == _count)
				GetComponentInParent<SellController>().Refresh();
			else
				SetItem(_food.food.thumbnail, _food.food.foodName, _food.count);
        }
    }
}