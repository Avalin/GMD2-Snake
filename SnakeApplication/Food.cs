using SnakeApplication.Properties;
using System.Drawing;

namespace SnakeApplication
{
    class Food : TileItem, IDrawable
    {
        public int MValue { get; set; }
        public FoodType MFoodType { get; set; }
        public bool MIsEaten { get; set; }

        private Image foodImg;
        private Snake snake;
        public enum FoodType
        {
            Pizza,
            CherryCola,
            Cookie
        }


        public Food(FoodType foodType, int value, Snake snake) 
        {
            MFoodType = foodType;
            MValue = value;
            MIsEaten = false;
            this.snake = snake;
            AssignImage();
        }

        private void AssignImage() 
        {
            switch (MFoodType)
            {
                case FoodType.Pizza:
                    foodImg = Resources.Pizza;
                    break;
                case FoodType.CherryCola:
                    foodImg = Resources.CherryCola;
                    break;
                case FoodType.Cookie:
                    foodImg = Resources.Cookie;
                    break;
                default:
                    foodImg = Resources.Pizza;
                    break;
            }
        }

        public void Draw(MapManager mm, Graphics gfx)
        {
            if (!MIsEaten) 
            {
                Tile tile = mm.GetTileWithItem(this);
                if (tile != null) gfx.DrawImage(foodImg, tile.X * mm.GetTileSize(), tile.Y * mm.GetTileSize(), mm.GetTileSize(), mm.GetTileSize());
                else MIsEaten = true;
            }
        }

        public override void OnCollision()
        {
            if (!MIsEaten) 
            {
                snake.EatFood(this);
                MIsEaten = true;
            }
        }
    }
}
