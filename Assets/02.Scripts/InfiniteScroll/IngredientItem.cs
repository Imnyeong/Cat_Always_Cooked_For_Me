using UnityEngine;
using UnityEngine.UI;

namespace Imnyeong
{
    public class IngredientItem : MonoBehaviour
    {
		[SerializeField]
		private Image thumbnail;
		[SerializeField]
		private Text nameText;
		[SerializeField]
		private Text countText;

		private Image ingredientThmbnail;
		private string ingredientName;
		private int ingredientCount;

		public void UpdateItem(Ingredient _ingredient)
		{
			ingredientThmbnail.sprite = _ingredient.ingredient.thumbnail;
			ingredientName = _ingredient.ingredient.ingredientName;
			ingredientCount = _ingredient.count;

			SetItem(ingredientThmbnail.sprite, ingredientName, ingredientCount);
		}

		public void SetItem(Sprite _image, string _name, int _count)
        {
			thumbnail.sprite = _image;
			nameText.text = _name;
			countText.text = _count.ToString();
		}
	}
}