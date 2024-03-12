using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Imnyeong
{
    public class LocalDataBase : MonoBehaviour
    {
        public static LocalDataBase instance;
        public List<Tuple<Item, int>> inventory = new List<Tuple<Item, int>>();

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