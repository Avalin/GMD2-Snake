using SnakeApplication.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApplication
{
    class SnakePart : TileItem, Drawable
    {
        private readonly bool debug = false;
        private Bitmap snakeImg;
        private readonly SnakeDirection snakeDirection;
        public enum PartType
        {
            Head,
            Body,
            Tail
        }
        PartType currentPartType;

        public SnakePart() 
        {
            SetSnakePartType(PartType.Tail);
            snakeDirection = new SnakeDirection();
        }

        public SnakeDirection GetSnakeDirection() 
        {
            return snakeDirection;
        }

        public void SetSnakePartDirection(SnakeDirection.Direction direction)
        {
            snakeDirection.SetCurrentDirection(direction);

            switch (snakeDirection.GetCurrentDirection())
            {
                case SnakeDirection.Direction.Up:
                    if (debug) Console.WriteLine("Direction is upwards");
                    snakeImg.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;

                case SnakeDirection.Direction.Down:
                    if (debug) Console.WriteLine("Direction is downwards");
                    snakeImg.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;

                case SnakeDirection.Direction.Left:
                    if (debug) Console.WriteLine("Direction is left");
                    snakeImg.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                    break;

                case SnakeDirection.Direction.Right:
                    if (debug) Console.WriteLine("Direction is right");
                    snakeImg.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
            }
        }



        public void SetSnakePartType(PartType type) 
        {
            currentPartType = type;
            AssignImage();
        }

        public PartType GetSnakePartType() 
        {
            return currentPartType;
        }

        public override void OnCollision()
        {

        }

        private void AssignImage() 
        {
            switch (currentPartType) 
            {
                case PartType.Head:
                    snakeImg = Resources.SnakeHead;
                    break;
                case PartType.Body:
                    snakeImg = Resources.SnakeBody;
                    break;
                case PartType.Tail:
                    snakeImg = Resources.SnakeTail;
                    break;
                default:
                    snakeImg = Resources.SnakeTail;
                    break; 
            }
        }

        public void Draw(MapManager mm, Graphics gfx)
        {
            Tile tile = mm.GetTileWithItem(this);
            if (tile == null)
            {
                throw new Exception("unable to find tile for snake part");
            }
            else
            {
                gfx.DrawImage(snakeImg, tile.X * mm.GetTileSize(), tile.Y * mm.GetTileSize(), snakeImg.Width, snakeImg.Height);
            }
        }
    }
}
