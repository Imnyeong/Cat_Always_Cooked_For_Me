using System;
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
        public void GetIngredient(AbilityType _type, int _value, int _count = 1)
        {
            if (FindIngredientData(_type, _value) != null)
            {
                if (FindIngredient(currentIngredientData))
                {
                    currentIngredient.count += _count;
                    //Debug.Log($"currentIngredient = {currentIngredient.ingredient.abilityType}, {currentIngredient.ingredient.abilityValue}, currentCount = {currentIngredient.count}");
                }
                else
                {
                    Ingredient newIngredient = new Ingredient();
                    newIngredient.ingredient = currentIngredientData;
                    newIngredient.count = _count;
                    //Debug.Log($"newIngredient = {newIngredient.ingredient.abilityType}, {newIngredient.ingredient.abilityValue}, newCount = {newIngredient.count}");
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
            for (int i = 0; i < _food.requiredIngredients.Count; i++)
            {
                currentIngredient = localDataBase.ingredientInventory.Find(x => x.ingredient == _food.requiredIngredients[i]);

                if (currentIngredient == null || currentIngredient.count < _food.requiredCounts[i])
                {
                    Debug.Log("재료 부족");
                    currentIngredient = null;
                    return false;
                }
            }
            return true;
        }
        public void UseIngredient(FoodData _food)
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

            UseIngredient(_data);

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
        public void SellFood(FoodData _data, int _count)
        {
            if (!FindFood(_data) || currentFood.count < _count)
            {
                Debug.Log("옳지 않은 판매");
                return;
            }
            else
            {
                //if (currentFood.count  == _count)
                //{
                //    localDataBase.foodInventory.Remove(currentFood);
                //}
                //else
                //{
                currentFood.count -= _count;
                //}
                GetMoney(_data.price * _count);
            }
            currentFood = null;
        }

        public void CleanFoodInventory()
        {
            for(int i = 0 ; i < localDataBase.foodInventory.Count ; i++)
            {
                localDataBase.foodInventory.RemoveAll(x => x.count == 0);
            }
        }
        #endregion
        #region Money
        public void GetMoney(int _price)
        {
            if(localDataBase.currentMoney + _price >= int.MaxValue)
            {
                localDataBase.currentMoney = int.MaxValue;

            }
            else
            {
                localDataBase.currentMoney += _price;
            }
            UIManager.instance.RefreshUI();
        }
        public bool LoseMoney(int _price)
        {
            if (localDataBase.currentMoney - _price <= 0)
            {
                return false;
            }
            else
            {
                localDataBase.currentMoney -= _price;
                UIManager.instance.RefreshUI();
                return true;
            }
        }
        #endregion
        #region Save
        public void SaveData()
        {
            SaveCat();

            SaveData saveData = new SaveData()
            {
                catList = localDataBase.catList,
                ingredientInventory = localDataBase.ingredientInventory,
                foodInventory = localDataBase.foodInventory,
                currentMoney = localDataBase.currentMoney,
                currentCash = localDataBase.currentCash,
                currentChur = localDataBase.currentChur,
            };

            PlayerPrefs.SetString("saveData", JsonUtility.ToJson(saveData));
            PlayerPrefs.SetString("saveTime", DateTime.Now.ToString());
        }

        public void LoadData()
        {
            string saveDataString = PlayerPrefs.GetString("saveData");
            string saveTimeString = PlayerPrefs.GetString("saveTime");

            if (saveTimeString == string.Empty || saveDataString == string.Empty)
                return;

            SaveData saveData = JsonUtility.FromJson<SaveData>(saveDataString);
            
            localDataBase.catList = saveData.catList;
            localDataBase.ingredientInventory = saveData.ingredientInventory;
            localDataBase.foodInventory = saveData.foodInventory;
            localDataBase.currentMoney = saveData.currentMoney;
            localDataBase.currentCash = saveData.currentCash;
            localDataBase.currentChur = saveData.currentChur;

            TimeSpan timeSpan = DateTime.Now - DateTime.Parse(saveTimeString);

            UIManager.instance.SetCats(saveData.catList);
            
            for (int i = 0; i < UIManager.instance.cats.Count; i++)
            {
                if (UIManager.instance.cats[i].gameObject.activeSelf)
                    UIManager.instance.cats[i].CalculateWorkPoint((int)(timeSpan.TotalSeconds));
            }
            UIManager.instance.RefreshUI();
        }
        public void SaveCat()
        {
            localDataBase.catList.Clear();
            for (int i = 0; i < UIManager.instance.cats.Count; i++)
            {
                if (UIManager.instance.cats[i].gameObject.activeSelf)
                {
                    CatData tmpData = new CatData()
                    {
                        abilityType = UIManager.instance.cats[i].abilityType,
                        abilityValue = UIManager.instance.cats[i].abilityValue,
                        maxWorkPoint = UIManager.instance.cats[i].maxWorkPoint,
                        currentWorkPoint = UIManager.instance.cats[i].currentWorkPoint,
                        workDelay = UIManager.instance.cats[i].workDelay
                    };
                    localDataBase.catList.Add(tmpData);
                }
            }
        }
       
        #endregion
    }
}
