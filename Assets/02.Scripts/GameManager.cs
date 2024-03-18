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

        private Food currentFood = null;

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
        public bool CheckIngredients(FoodData _food)
        {
            int checkCount = 0;

            for (int i = 0; i < _food.requiredIngredients.Count; i++)
            {
                currentIngredient = localDataBase.ingredientInventory.Find(x => x.ingredient == _food.requiredIngredients[i]);

                if (currentIngredient == null || currentIngredient.count < _food.requiredCounts[i])
                {
                    Debug.Log("재료 부족");
                    currentIngredient = null;
                    return false;
                }
                else 
                {
                    checkCount++;
                }
            }
            if(checkCount == _food.requiredIngredients.Count)
            {
                for (int i = 0; i < _food.requiredIngredients.Count; i++)
                {
                    currentIngredient = localDataBase.ingredientInventory.Find(x => x.ingredient == _food.requiredIngredients[i]);

                    if (currentIngredient.count == _food.requiredCounts[i])
                    {
                        localDataBase.ingredientInventory.Remove(currentIngredient);
                    }
                    else
                    {
                        currentIngredient.count -= _food.requiredCounts[i];
                    }
                }
                Debug.Log("요리 성공");
                return true;
            }
            return false;
        }
        public bool FindFood(FoodData _data)
        {
            currentFood = localDataBase.foodInventory.Find(x => x.food == _data);
            return currentFood != null;
        }
        public void GetFood(FoodData _data)
        {
            if(!CheckIngredients(_data))
                return;

            if (FindFood(_data))
            {
                currentFood.count++;
            }
            else
            {
                Food newFood = new Food();
                newFood.food = _data;
                newFood.count = 1;
                localDataBase.foodInventory.Add(newFood);
            }

            currentIngredient = null;
            currentFood = null;
        }
        public void SellFood(FoodData _data)
        {
            if (!FindFood(_data))
            {
                return;
            }
            else
            {
                if (currentFood.count > 1)
                {
                    currentFood.count--;
                }
                else
                {
                    localDataBase.foodInventory.Remove(currentFood);
                }
            }
            currentFood = null;
        }
        #endregion
        #region Money
        public void GetMoney(int _price)
        {

        }
        #endregion
    }
}
