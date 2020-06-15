using SnakeApplication.Properties;
using System.Drawing;

namespace SnakeApplication
{
    class Food : TileItem, Drawable
    {
        private Image foodImg;
        public int _Value { get; set; }
        public FoodType _FoodType { get; set; }

        public enum FoodType
        {
            Pizza,
            Cheese,
            Cookie
        }


        public Food(FoodType foodType, int value) 
        {
            _FoodType = foodType;
            _Value = value;
            AssignImage();
        }

        private void AssignImage() 
        {
            switch (_FoodType)
            {
                case FoodType.Pizza:
                    foodImg = Resources.Pizza;
                    break;
                case FoodType.Cheese:
                    foodImg = Resources.Pizza;
                    break;
                case FoodType.Cookie:
                    foodImg = Resources.Pizza;
                    break;
                default:
                    foodImg = Resources.Pizza;
                    break;
            }
        }

        public void Draw(MapManager mm, Graphics gfx)
        {
            Tile tile = mm.GetTileWithItem(this);
            gfx.DrawImage(foodImg, tile.X* mm.GetTileSize(), tile.Y* mm.GetTileSize(), mm.GetTileSize(), mm.GetTileSize());
        }

        public override void OnCollision()
        {

        }
    }
}
