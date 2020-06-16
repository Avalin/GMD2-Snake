using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeApplication
{
    class FoodManager
    {
        bool debug = false;
        Random random = new Random();
        List<Food> foodies = new List<Food>();

        public FoodManager(Snake snake) 
        {
            CreateFoodType(Food.FoodType.Pizza, 1, snake);
            CreateFoodType(Food.FoodType.CherryCola, 1, snake);
            CreateFoodType(Food.FoodType.Cookie, 2, snake);

            #region Debug Tool
            if (debug) 
            {
                foreach (Food food in foodies) 
                {
                    Console.WriteLine(food.MFoodType + " is created with value " + food.MValue + ".");
                }
            }
            #endregion debug
        }

        void CreateFoodType(Food.FoodType type, int value, Snake snake) 
        {
            Food food = new Food(type, value, snake);
            foodies.Add(food);
        }

        public Food SpawnFoodOnTile(MapManager mm) 
        {
            int range = random.Next(foodies.Count());
            Food foodie = foodies.ElementAt(range);
            mm.PlaceItemOnTile(mm.GetRandomTile(), foodie);
            foodie.MIsEaten = false;
            return foodie;
        }
    }
}
