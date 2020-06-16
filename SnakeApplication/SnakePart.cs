using SnakeApplication.Properties;
using System;
using System.Drawing;

namespace SnakeApplication
{
    class SnakePart : TileItem, IDrawable
    {
        private readonly bool debug = false;
        private Bitmap snakeImgSource;
        private Bitmap snakeImg;
        private readonly SnakePartDirection snakeDirection;
        SnakePartType currentPartType;

        public SnakePart() 
        {
            SetSnakePartType(SnakePartType.Tail);
            snakeDirection = new SnakePartDirection();
            SetSnakePartDirection(Direction.Left);
        }

        public SnakePartDirection GetSnakeDirection() 
        {
            return snakeDirection;
        }

        public void SetSnakePartDirection(Direction direction)
        {
            snakeDirection.SetCurrentDirection(direction);

            switch (snakeDirection.GetCurrentDirection())
            {
                case Direction.Up:
                    if (debug) Console.WriteLine("Direction is upwards");
                    snakeImg = Program.RotateImage(snakeImgSource, 90);
                    break;

                case Direction.Down:
                    if (debug) Console.WriteLine("Direction is downwards");
                    snakeImg = Program.RotateImage(snakeImgSource, 270);
                    break;

                case Direction.Left:
                    if (debug) Console.WriteLine("Direction is left");
                    snakeImg = snakeImgSource;
                    break;

                case Direction.Right:
                    if (debug) Console.WriteLine("Direction is right");
                    snakeImg = Program.RotateImage(snakeImgSource, 180);
                    break;
            }
        }

        public void SetSnakePartType(SnakePartType type) 
        {
            currentPartType = type;
            AssignImage();
        }

        public SnakePartType GetSnakePartType() 
        {
            return currentPartType;
        }

        public override void OnCollision()
        {
            if(debug) Console.WriteLine("GAME ENDED.");
            GameStateManager.EndGame();
        }

        private void AssignImage() 
        {
            switch (currentPartType) 
            {
                case SnakePartType.Head:
                    snakeImgSource = Resources.SnakeHead;
                    snakeImg = Resources.SnakeHead;
                    break;
                case SnakePartType.Body:
                    snakeImgSource = Resources.SnakeBody;
                    snakeImg = Resources.SnakeBody;
                    break;
                case SnakePartType.Tail:
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
