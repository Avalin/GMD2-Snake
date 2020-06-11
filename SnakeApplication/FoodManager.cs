using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApplication
{
    struct Food 
    {
        public string Type;
        public int Value;
    }
    class FoodManager
    {
        bool debug = false;
        List<Food> foodies = new List<Food>();

        public FoodManager() 
        {
            CreateFoodType("Apple", 1);
            CreateFoodType("Orange", 1);
            CreateFoodType("Tomato", 1);
            CreateFoodType("Durian", 2);

            #region Debug Tool
            if (debug) 
            {
                foreach (Food food in foodies) 
                {
                    Console.WriteLine(food.Type + " is created with value " + food.Value + ".");
                }
            }
            #endregion debug
        }

        void CreateFoodType(string type, int value) 
        {
            Food newFoodType = new Food
            {
                Type = type,
                Value = value
            };
            foodies.Add(newFoodType);
        }
    }
}
