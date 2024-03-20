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

		public void UpdateItem(int count)
		{
			foodThmbnail = GameManager.instance.localDataBase.foodInventory[count].food.thumbnail;
			foodName = GameManager.instance.localDataBase.foodInventory[count].food.foodName;
			foodCount = GameManager.instance.localDataBase.foodInventory[count].count;
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