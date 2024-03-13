using System.Collections.Generic;
using UnityEngine;

namespace Imnyeong
{
    public class ItemManager : MonoBehaviour
    {
        public static ItemManager instance;
        public List<Item> allItems;

        private Item currentData = null;
        private ConsumptionItem currentItem = null;
        private void Awake()
        {
            DontDestroyOnLoad(this);

            if (instance == null)
            {
                instance = this;
            }
        }
        public Item FindData(AbilityType _type, int _value)
        {
            currentData = allItems.Find(x => x.abilityType == _type && x.abilityValue == _value);

            if (currentData != null)
                return currentData;
            else
                return null;
        }
        public bool FindItem(Item _item)
        {
            currentItem = LocalDataBase.instance.consumptionInventory.Find(x => x.item == _item);
            return currentItem != null;
        }
        public void GetItem(AbilityType _type, int _value)
        {

            if (FindData(_type, _value) != null)
            {
                if (FindItem(currentData))
                {
                    currentItem.count++;
                    Debug.Log($"currentType = {currentItem.item.abilityType}, currentValue = {currentItem.item.abilityValue}, currentCount = {currentItem.count}");
                }
                else
                {
                    ConsumptionItem newItem = new ConsumptionItem();
                    newItem.item = currentData;
                    newItem.count = 1;
                    Debug.Log($"newType = {newItem.item.abilityType}, newValue = {newItem.item.abilityValue}, newCount = {newItem.count}");
                    LocalDataBase.instance.consumptionInventory.Add(newItem);
                }
            }

            currentData = null;
            currentItem = null;
        }
    }
}
