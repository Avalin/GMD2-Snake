using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApplication
{
    class Snake : Drawable
    {
        private readonly bool debug = true;
        private readonly SnakeDirection snakeDirection;
        private int score;

        private LinkedList<SnakeTail> snakeTails;
        Graphics gfx = null;

        public Snake(int length)
        {
            score = 0;
            snakeDirection = new SnakeDirection();
            snakeTails = new LinkedList<SnakeTail>();
            SetSnakeDirection(SnakeDirection.Direction.Right);

            for (int i = 0; i <= length; i++) 
            {
                AddSnakeTail();
            }
        }

        public void SetSnakeDirection(SnakeDirection.Direction direction) 
        {
            snakeDirection.SetCurrentDirection(direction);
        }

        public void AddSnakeTail() 
        {
            snakeTails.AddLast(new SnakeTail());
        }

        public void EatFood(Food food) 
        {
            score += food.value;
            AddSnakeTail();

            #region Debug Tools
            if (debug) 
            {
                Console.WriteLine("Snake ate " + food.type + " for a value of " + food.value + ".");
                Console.WriteLine("Snake now has a score of " + score + " and a length of " + snakeTails.Count() + ".");
            }
            #endregion Debug Tools
        }

        public void Draw()
        {
        
        }
    }
}
