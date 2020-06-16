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
        private Bitmap snakeImgSource;
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
            SetSnakePartDirection(SnakeDirection.Direction.Left);
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
                    snakeImg = Program.RotateImage(snakeImgSource, 90);
                    break;

                case SnakeDirection.Direction.Down:
                    if (debug) Console.WriteLine("Direction is downwards");
                    snakeImg = Program.RotateImage(snakeImgSource, 270);
                    break;

                case SnakeDirection.Direction.Left:
                    if (debug) Console.WriteLine("Direction is left");
                    snakeImg = snakeImgSource;
                    break;

                case SnakeDirection.Direction.Right:
                    if (debug) Console.WriteLine("Direction is right");
                    snakeImg = Program.RotateImage(snakeImgSource, 180);
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
            Console.WriteLine("GAME ENDED.");
            GameStateManager.EndGame();
        }

        private void AssignImage() 
        {
            switch (currentPartType) 
            {
                case PartType.Head:
                    snakeImgSource = Resources.SnakeHead;
                    snakeImg = Resources.SnakeHead;
                    break;
                case PartType.Body:
                    snakeImgSource = Resources.SnakeBody;
                    snakeImg = Resources.SnakeBody;
                    break;
                case PartType.Tail:
                    snakeImgSource = Resources.SnakeTail;
                    snakeImg = Resources.SnakeTail;
                    break;
                default:
                    snakeImgSource = Resources.SnakeTail;
                    snakeImg = Resources.SnakeTail;
                    break; 
            }
        }

        public void Draw(MapManager mm, Graphics gfx)
        {
            Tile tile = mm.GetTileWithItem(this);
            if (tile != null)
            {
                gfx.DrawImage(snakeImg, tile.X * mm.GetTileSize(), tile.Y * mm.GetTileSize(), snakeImg.Width, snakeImg.Height);
            }
        }
    }
}
