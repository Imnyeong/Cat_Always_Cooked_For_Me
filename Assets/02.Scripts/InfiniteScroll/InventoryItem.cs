using UnityEngine;
using UnityEngine.UI;

namespace Imnyeong
{
    public class InventoryItem : MonoBehaviour
    {
		[SerializeField]
		Image thumbnail;
		[SerializeField]
		Text nameText;
		[SerializeField]
		Text countText;

		public void UpdateItem(int count)
		{
			thumbnail = GameManager.instance.localDataBase.ingredientInventory[count].ingredient.thumbnail;
			nameText.text = GameManager.instance.localDataBase.ingredientInventory[count].ingredient.name;
			countText.text = GameManager.instance.localDataBase.ingredientInventory[count].count.ToString();
		}
	}
}