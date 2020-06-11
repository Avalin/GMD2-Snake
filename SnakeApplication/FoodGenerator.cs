using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApplication
{
    struct Food 
    {
        public string type;
        public int value;
    }
    class FoodGenerator
    {
        bool debug = true;
        List<Food> foodies = new List<Food>();

        public FoodGenerator() 
        {
            CreateFoodType("Apple", 1);
            CreateFoodType("Orange", 1);
            CreateFoodType("Tomato", 1);
            CreateFoodType("Durian", 2);

            if (debug) 
            {
                foreach (Food food in foodies) 
                {
                    Console.WriteLine(food.type + " is created with" + food.value + "value.");
                }
            }
        }

        void CreateFoodType(string type, int value) 
        {
            Food newFoodType = new Food();
            newFoodType.type = type;
            newFoodType.value = value;
            foodies.Add(newFoodType);
        }
    }
}
