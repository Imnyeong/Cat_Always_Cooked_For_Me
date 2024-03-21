using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Imnyeong
{
	[RequireComponent(typeof(InfiniteScroll))]
	public class IngredientController : MonoBehaviour, IInfiniteScrollSetup
	{
		private List<Ingredient> ingredients;
		private int max;

		public void OnPostSetupItems()
		{
			ingredients = GameManager.instance.localDataBase.ingredientInventory;
			max = ingredients.Count;

			var infiniteScroll = GetComponent<InfiniteScroll>();
			infiniteScroll.onUpdateItem.AddListener(OnUpdateItem);
			GetComponentInParent<ScrollRect>().movementType = ScrollRect.MovementType.Clamped;

			var rectTransform = GetComponent<RectTransform>();
			var delta = rectTransform.sizeDelta;
			delta.y = infiniteScroll.itemScale * max;
			rectTransform.sizeDelta = delta;
		}

		public void OnUpdateItem(int itemCount, GameObject obj)
		{
			if (itemCount < 0 || itemCount >= max)
			{
				obj.SetActive(false);
			}
			else
			{
				obj.SetActive(true);
				var item = obj.GetComponentInChildren<IngredientItem>();
				item.UpdateItem(ingredients[itemCount]);
			}
		}
	}
}
