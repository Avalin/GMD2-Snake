using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApplication
{
    class SnakeDirection
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right,
        }
        Direction currentDirection = Direction.Left;

        public Direction GetCurrentDirection() 
        {
            return currentDirection;
        }

        public void SetCurrentDirection(Direction direction) 
        {
            currentDirection = direction;
        }
    }
}
