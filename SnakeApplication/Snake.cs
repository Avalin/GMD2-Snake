using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApplication
{
    class Snake
    {
        bool debug = true;
        int score;
        int length;

        public Snake(int length) 
        {
            score = 0;
            this.length = length;
        }

        void EatFood(Food food) 
        {
            score += food.Value;
            length++;

            #region Debug Tools
            if (debug) 
            {
                Console.WriteLine("Snake ate " + food.Type + " for a value of " + food.Value + ".");
                Console.WriteLine("Snake now has a score of " + score + " and a length of " + length + ".");
            }
            #endregion Debug Tools
        }
    }
}
