using System.Collections.Generic;
using UnityEngine;

namespace Imnyeong
{
    public class LocalDataBase : MonoBehaviour
    {
        [Header("Cat")]
        public List<Cat> catList = new List<Cat>();
        [Header("Inventory")]
        public List<Ingredient> ingredientInventory = new List<Ingredient>();
        public List<Food> foodInventory = new List<Food>();
        public int currentMoney = 0;

        public void ShowInventory()
        {
            for (int i = 0; i < ingredientInventory.Count; i++)
            {
                Debug.Log($"��� �̸� = {ingredientInventory[i].ingredient} ���� {ingredientInventory[i].count}");
            }
            for (int i = 0; i < foodInventory.Count; i++)
            {
                Debug.Log($"���� �̸� = {foodInventory[i].food} ���� {foodInventory[i].count}");
            }
        }
    }
}