using System.Collections.Generic;
using UnityEngine;

namespace Imnyeong
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        
        public List<IngredientData> ingredientDatas;
        private IngredientData currentIngredientData = null;
        
        private Ingredient currentIngredient = null;

        private void Awake()
        {
            DontDestroyOnLoad(this);

            if (instance == null)
            {
                instance = this;
            }
        }
        public IngredientData FindData(AbilityType _type, int _value)
        {
            currentIngredientData = ingredientDatas.Find(x => x.abilityType == _type && x.abilityValue == _value);

            if (currentIngredientData != null)
                return currentIngredientData;
            else
                return null;
        }
        public bool FindItem(IngredientData _item)
        {
            currentIngredient = LocalDataBase.instance.consumptionInventory.Find(x => x.item == _item);
            return currentIngredient != null;
        }
        public void GetItem(AbilityType _type, int _value)
        {
            if (FindData(_type, _value) != null)
            {
                if (FindItem(currentIngredientData))
                {
                    currentIngredient.count++;
                    Debug.Log($"currentIngredient = {currentIngredient.item.abilityType}, {currentIngredient.item.abilityValue}, currentCount = {currentIngredient.count}");
                }
                else
                {
                    Ingredient newIngredient = new Ingredient();
                    newIngredient.item = currentIngredientData;
                    newIngredient.count = 1;
                    Debug.Log($"newIngredient = {newIngredient.item.abilityType}, {newIngredient.item.abilityValue}, newCount = {newIngredient.count}");
                    LocalDataBase.instance.consumptionInventory.Add(newIngredient);
                }
            }

            currentIngredientData = null;
            currentIngredient = null;
        }
    }
}
