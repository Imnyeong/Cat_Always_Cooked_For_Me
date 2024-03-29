using System;
using System.Collections.Generic;

namespace Imnyeong
{
    public class SaveData
    {
        public List<CatData> catList;
        public List<Ingredient> ingredientInventory = new List<Ingredient>();
        public List<Food> foodInventory = new List<Food>();
        public int currentMoney;
        public int currentCash;
        public int currentChur;
    }
}
