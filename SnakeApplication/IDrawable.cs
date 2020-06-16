using System.Drawing;

namespace SnakeApplication
{
    interface IDrawable
    {
        void Draw(MapManager mm, Graphics gfx);
    }
}
