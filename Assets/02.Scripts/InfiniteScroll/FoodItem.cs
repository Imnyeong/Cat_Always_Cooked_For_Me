using UnityEngine;
using UnityEngine.UI;

namespace Imnyeong
{
    public class FoodItem : MonoBehaviour
    {
		[SerializeField]
		private Image thumbnail;
		[SerializeField]
		private Text nameText;
		[SerializeField]
		private Text countText;

		private Image foodThmbnail;
		private string foodName;
		private int foodCount;

		public void UpdateItem(Food _food)
		{
			foodThmbnail.sprite = _food.food.thumbnail;
			foodName = _food.food.foodName;
			foodCount = _food.count;

			SetItem(foodThmbnail.sprite, foodName, foodCount);
		}

		public void SetItem(Sprite _image, string _name, int _count)
        {
			thumbnail.sprite = _image;
			nameText.text = _name;
			countText.text = _count.ToString();
		}
	}
}