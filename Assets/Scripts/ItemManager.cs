using UnityEngine;

namespace Imnyeong
{
    public class ItemManager : MonoBehaviour
    {
        public static ItemManager instance;

        private void Awake()
        {
            DontDestroyOnLoad(this);

            if (instance == null)
            {
                instance = this;
            }
        }
        public void FindItem(Item _item)
        {
            if(LocalDataBase.instance.inventory.Find(x => x.Item1 == _item) != null)
            {

            }    
        }
        public void GetItem(AbilityType _type, int _value)
        {
            switch (_type)
            {
                case AbilityType.Fire:
                    {
                        Debug.Log($"불 {_value} 포인트");
                        break;
                    }
                case AbilityType.Wood:
                    {
                        Debug.Log($"나무 {_value} 포인트");
                        break;
                    }
                case AbilityType.Rice:
                    {
                        Debug.Log($"쌀 {_value} 포인트");
                        break;
                    }
                case AbilityType.Fish:
                    {
                        Debug.Log($"낚시 {_value} 포인트");
                        break;
                    }
            }
        }
    }
}
