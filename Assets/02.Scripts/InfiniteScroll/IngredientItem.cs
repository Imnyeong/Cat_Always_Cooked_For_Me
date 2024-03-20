using UnityEngine;
using UnityEngine.UI;

namespace Imnyeong
{
    public class IngredientItem : MonoBehaviour
    {
		[SerializeField]
		Image thumbnail;
		[SerializeField]
		Text nameText;
		[SerializeField]
		Text countText;

		private Image ingredientThmbnail;
		private string ingredientName;
		private int ingredientCount;

		public void UpdateItem(int count)
		{
			ingredientThmbnail = GameManager.instance.localDataBase.ingredientInventory[count].ingredient.thumbnail;
			ingredientName = GameManager.instance.localDataBase.ingredientInventory[count].ingredient.ingredientName;
			ingredientCount = GameManager.instance.localDataBase.ingredientInventory[count].count;
			SetItem(ingredientThmbnail, ingredientName, ingredientCount);
		}

		public void SetItem(Image _image, string _name, int _count)
        {
			thumbnail = _image;
			nameText.text = _name;
			countText.text = _count.ToString();
		}
	}
}