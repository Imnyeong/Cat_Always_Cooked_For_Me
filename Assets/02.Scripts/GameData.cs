using System.Collections.Generic;
using UnityEngine;

namespace Imnyeong
{
    public class GameData : MonoBehaviour
    {
        [Header("Ingredient")]
        public List<IngredientData> ingredientDatas;
        [Header("Food")]
        public List<FoodData> FoodDatas;
    }
}