﻿using SnakeApplication.Properties;
using System;
using System.Drawing;

namespace SnakeApplication
{
    class Food : TileItem, Drawable
    {
        public int _Value { get; set; }
        public FoodType _FoodType { get; set; }
        public bool _IsEaten { get; set; }

        private Image foodImg;
        private Snake snake;
        public enum FoodType
        {
            Pizza,
            Cheese,
            Cookie
        }


        public Food(FoodType foodType, int value, Snake snake) 
        {
            _FoodType = foodType;
            _Value = value;
            _IsEaten = false;
            this.snake = snake;
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
            if (!_IsEaten) 
            {
                Tile tile = mm.GetTileWithItem(this);
                if (tile != null) gfx.DrawImage(foodImg, tile.X * mm.GetTileSize(), tile.Y * mm.GetTileSize(), mm.GetTileSize(), mm.GetTileSize());
                else _IsEaten = true;
            }
        }

        public override void OnCollision()
        {
            if (!_IsEaten) 
            {
                snake.EatFood(this);
                _IsEaten = true;
            }
        }
    }
}
