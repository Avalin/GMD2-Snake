using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApplication
{
    class SnakeDirection
    {
        bool debug = false;
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right,
        }
        Direction currentDirection;

        public void SetCurrentDirection(Direction direction) 
        {
            currentDirection = direction;
            switch (currentDirection)
            {
                case Direction.Up:
                    if (debug) Console.WriteLine("Direction is upwards");
                    break;

                case Direction.Down:
                    if (debug) Console.WriteLine("Direction is downwards");
                    break;

                case Direction.Left:
                    if (debug) Console.WriteLine("Direction is left");
                    break;

                case Direction.Right:
                    if (debug) Console.WriteLine("Direction is right");
                    break;
            }
        }
    }
}
