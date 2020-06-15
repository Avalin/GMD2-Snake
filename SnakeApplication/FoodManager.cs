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
            CreateFoodType(Food.FoodType.Pizza, 1);
            CreateFoodType(Food.FoodType.Cheese, 1);

            #region Debug Tool
            if (debug) 
            {
                foreach (Food food in foodies) 
                {
                    Console.WriteLine(food._FoodType + " is created with value " + food._Value + ".");
                }
            }
            #endregion debug
        }

        void CreateFoodType(Food.FoodType type, int value) 
        {
            Food food = new Food(type, value);
            foodies.Add(food);
        }

        public Food SpawnFoodOnTile(MapManager mm) 
        {
            var random = new Random();
            int range = random.Next(foodies.Count() - 1);
            Food foodie = foodies.ElementAt(range);
            mm.PlaceItemOnTile(mm.GetRandomTile(), foodie);
            return foodie;
        }
    }
}
