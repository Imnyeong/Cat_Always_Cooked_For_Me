using System.Collections.Generic;
using UnityEngine;

namespace Imnyeong
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public GameData gameData;
        public LocalDataBase localDataBase;

        private IngredientData currentIngredientData = null;        
        private Ingredient currentIngredient = null;

        #region Unity Life Cycle
        private void Awake()
        {
            DontDestroyOnLoad(this);

            if (instance == null)
            {
                instance = this;
            }
        }
        #endregion
        #region Ingredient
        public IngredientData FindIngredientData(AbilityType _type, int _value)
        {
            currentIngredientData = gameData.ingredientDatas.Find(x => x.abilityType == _type && x.abilityValue == _value);

            if (currentIngredientData != null)
                return currentIngredientData;
            else
                return null;
        }
        public bool FindIngredient(IngredientData _data)
        {
            currentIngredient = localDataBase.ingredientInventory.Find(x => x.ingredient == _data);
            return currentIngredient != null;
        }
        public void GetIngredient(AbilityType _type, int _value)
        {
            if (FindIngredientData(_type, _value) != null)
            {
                if (FindIngredient(currentIngredientData))
                {
                    currentIngredient.count++;
                    Debug.Log($"currentIngredient = {currentIngredient.ingredient.abilityType}, {currentIngredient.ingredient.abilityValue}, currentCount = {currentIngredient.count}");
                }
                else
                {
                    Ingredient newIngredient = new Ingredient();
                    newIngredient.ingredient = currentIngredientData;
                    newIngredient.count = 1;
                    Debug.Log($"newIngredient = {newIngredient.ingredient.abilityType}, {newIngredient.ingredient.abilityValue}, newCount = {newIngredient.count}");
                    localDataBase.ingredientInventory.Add(newIngredient);
                }
            }

            currentIngredientData = null;
            currentIngredient = null;
        }
        #endregion
        #region Food

        #endregion
    }
}
