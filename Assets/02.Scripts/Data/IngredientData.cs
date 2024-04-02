using UnityEngine;
using UnityEngine.UI;

namespace Imnyeong
{
    [CreateAssetMenu]
    public class IngredientData : ScriptableObject
    {
        public Sprite thumbnail;
        public AbilityType abilityType;
        public int abilityIndex;
        public string ingredientName;
        public string description;
    }

    [System.Serializable]
    public class Ingredient
    {
        public IngredientData ingredient;
        public int count;
    }
}
