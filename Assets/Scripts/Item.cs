using UnityEngine;

namespace Imnyeong
{
    [CreateAssetMenu]
    public class Item: ScriptableObject
    {
        public AbilityType abilityType;
        public int abilityValue;
    }

    public class ConsumptionItem
    {
        public Item item;
        public int count;
    }
}
