using SnakeApplication.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApplication
{
    class SnakePart : TileItem
    {
        private Bitmap snakeImg;
        public enum PartType
        {
            Head,
            Body,
            Tail
        }
        PartType currentPartType;

        public SnakePart() 
        {
            SetSnakePartType(PartType.Body);
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
                    snakeImg = Resources.SnakeBody;
                    break; 
            }
        }
    }
}
