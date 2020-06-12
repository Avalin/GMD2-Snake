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

        private LinkedList<SnakePart> snakeParts;

        public Snake(int length)
        {
            score = 0;
            snakeDirection = new SnakeDirection();
            snakeParts = new LinkedList<SnakePart>();
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

        public int GetSnakeLength() 
        {
            return snakeParts.Count();
        }

        public SnakePart GetSnakePart(int i)
        {
            return snakeParts.ElementAt(i);
        }

        public void AddSnakeTail() 
        {
            snakeParts.AddLast(new SnakePart());

            snakeParts.First().SetSnakePartType(SnakePart.PartType.Head);
            snakeParts.Last().SetSnakePartType(SnakePart.PartType.Tail);
        }

        public void EatFood(Food food) 
        {
            score += food.value;
            AddSnakeTail();

            #region Debug Tools
            if (debug) 
            {
                Console.WriteLine("Snake ate " + food.type + " for a value of " + food.value + ".");
                Console.WriteLine("Snake now has a score of " + score + " and a length of " + snakeParts.Count() + ".");
            }
            #endregion Debug Tools
        }

        public void Draw()
        {

        }
    }
}
