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
                        Debug.Log($"�� {_value} ����Ʈ");
                        break;
                    }
                case AbilityType.Wood:
                    {
                        Debug.Log($"���� {_value} ����Ʈ");
                        break;
                    }
                case AbilityType.Rice:
                    {
                        Debug.Log($"�� {_value} ����Ʈ");
                        break;
                    }
                case AbilityType.Fish:
                    {
                        Debug.Log($"���� {_value} ����Ʈ");
                        break;
                    }
            }
        }
    }
}
