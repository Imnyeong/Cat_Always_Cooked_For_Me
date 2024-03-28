using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Imnyeong
{
    [CreateAssetMenu]
    public class FoodData : ScriptableObject
    {
        public Image thumbnail;
        public int price;
        public string foodName;
        public string description;
        public float requiredTime;
        public List<IngredientData> requiredIngredients;
        public List<int> requiredCounts;
    }

    [System.Serializable]
    public class Food
    {
        public FoodData food;
        public int count;
    }
}