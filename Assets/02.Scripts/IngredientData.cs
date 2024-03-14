using UnityEngine;
using UnityEngine.UI;

namespace Imnyeong
{
    [CreateAssetMenu]
    public class IngredientData : ScriptableObject
    {
        public Image thumbnail;
        public AbilityType abilityType;
        public int abilityValue;
    }

    public class Ingredient
    {
        public IngredientData item;
        public int count;
    }
}
