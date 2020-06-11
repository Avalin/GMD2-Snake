using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApplication
{
    class Food : TileItem, Drawable
    {
        public string type;
        public int value;

        public Food(string type, int value) 
        {
            this.type = type;
            this.value = value;
        }

        public void Draw()
        {

        }

        public override void GetImage()
        {
            throw new NotImplementedException();
        }

        public override void OnCollision()
        {

        }
    }
}
