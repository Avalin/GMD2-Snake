using SnakeApplication.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApplication
{
    class SnakeTail : TileItem
    {
        private Bitmap snakeImg;

        public SnakeTail() 
        {
            snakeImg = Resources.SnakeBody;
        }

        public override void OnCollision()
        {

        }
    }
}
