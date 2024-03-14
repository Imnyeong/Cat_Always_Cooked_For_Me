using System.Collections.Generic;
using UnityEngine;

namespace Imnyeong
{
    public class LocalDataBase : MonoBehaviour
    {
        public static LocalDataBase instance;
        public List<Ingredient> consumptionInventory = new List<Ingredient>();

        public List<Cat> catList = new List<Cat>();

        private void Awake()
        {
            DontDestroyOnLoad(this);

            if (instance == null)
            {
                instance = this;
            }
        }

    }
}