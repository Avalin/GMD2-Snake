using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApplication
{
    class Snake
    {
        int score = 0;
        int length = 3;

        void EatFood(Food food) 
        {
            score += food.Value;
            length++;
        }
    }
}
