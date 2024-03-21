using UnityEngine;
using UnityEngine.UI;

namespace Imnyeong
{
    public class FoodItem : MonoBehaviour
    {
		[SerializeField]
		Image thumbnail;
		[SerializeField]
		Text nameText;
		[SerializeField]
		Text countText;

		private Image foodThmbnail;
		private string foodName;
		private int foodCount;

		public void UpdateItem(Food _food)
		{
			foodThmbnail = _food.food.thumbnail;
			foodName = _food.food.foodName;
			foodCount = _food.count;

			SetItem(foodThmbnail, foodName, foodCount);
		}

		public void SetItem(Image _image, string _name, int _count)
        {
			thumbnail = _image;
			nameText.text = _name;
			countText.text = _count.ToString();
		}
	}
}