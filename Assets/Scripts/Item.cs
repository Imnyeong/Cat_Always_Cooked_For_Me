using UnityEngine;

namespace Imnyeong
{
    public abstract class Item: ScriptableObject
    {
        private AbilityType abilityType { get; }
        private int abilityValue { get; }
    }
}
