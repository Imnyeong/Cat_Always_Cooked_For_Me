using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Imnyeong
{
    public class LocalDataBase : MonoBehaviour
    {
        public static LocalDataBase instance;
        public List<ConsumptionItem> consumptionInventory = new List<ConsumptionItem>();

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