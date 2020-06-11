using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApplication
{
    abstract class TileItem
    {
        public abstract void GetImage();
        public abstract void OnCollision();
    }
}
