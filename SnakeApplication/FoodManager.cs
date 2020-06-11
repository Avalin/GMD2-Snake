using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApplication
{
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
                    Console.WriteLine(food.type + " is created with value " + food.value + ".");
                }
            }
            #endregion debug
        }

        void CreateFoodType(string type, int value) 
        {
            Food food = new Food(type, value);
            foodies.Add(food);
        }
    }
}
