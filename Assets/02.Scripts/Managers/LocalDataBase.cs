using System.Collections.Generic;
using UnityEngine;

namespace Imnyeong
{
    public class LocalDataBase : MonoBehaviour
    {
        [Header("Cat")]
        public List<CatData> catList = new List<CatData>();
        [Header("Inventory")]
        public List<Ingredient> ingredientInventory = new List<Ingredient>();
        public List<Food> foodInventory = new List<Food>();
        public int currentMoney = 0;
        public int currentCash = 0;
        public int currentChur = 0;

        public void ShowInventory()
        {
            for (int i = 0; i < ingredientInventory.Count; i++)
            {
                Debug.Log($"재료 이름 = {ingredientInventory[i].ingredient} 개수 {ingredientInventory[i].count}");
            }
            for (int i = 0; i < foodInventory.Count; i++)
            {
                Debug.Log($"음식 이름 = {foodInventory[i].food} 개수 {foodInventory[i].count}");
            }
        }
    }
}