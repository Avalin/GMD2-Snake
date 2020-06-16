using System;
using System.Collections.Generic;

namespace SnakeApplication
{
    class SnakeMover
    {
        Snake snake;

        public SnakeMover(Snake snake) 
        {
            this.snake = snake;
        }

        public bool _ShouldGrow { get; set; }

        public void MoveSnakeParts(LinkedList<SnakePart> snakeParts, MapManager mm) 
        {
            LinkedListNode<SnakePart> snakeHead = snakeParts.Last;
            Tile destinationTile = mm.GetTileInFrontOfSnakePart(snakeHead.Value);
            Tile currentTile = mm.GetTileWithItem(snakeParts.First.Value);
            mm.PlaceItemOnTile(currentTile, null);

            for (LinkedListNode<SnakePart> snakePartNode = snakeParts.First; snakePartNode != null;)
            {
                LinkedListNode<SnakePart> nextNode = snakePartNode.Next;
                if (nextNode != null)
                {
                    Tile nextTile = mm.GetTileWithItem(nextNode.Value);
                    if (nextTile == null)
                    {
                        throw new Exception("nextTile is null");
                    }
                    
                    mm.PlaceItemOnTile(nextTile, snakePartNode.Value);
                    snakePartNode.Value.SetSnakePartDirection(nextNode.Value.GetSnakeDirection().GetCurrentDirection());
                }
                else 
                {
                    //Moves snakehead to destination
                    if (destinationTile == null)
                    {
                        throw new Exception("destinationTile is null");
                    }
                    mm.PlaceItemOnTile(destinationTile, snakePartNode.Value);
                }
                snakePartNode = nextNode;
            }
            if (_ShouldGrow) GrowSnake(mm);
            HandleCollision(mm.GetTileInFrontOfSnakePart(snakeHead.Value));
        }

        void HandleCollision(Tile destinationTile) 
        {
            if(destinationTile.Item != null)
            destinationTile.Item.OnCollision();
        }

        void GrowSnake(MapManager mm) 
        {
            snake.AddSnakePart();
            mm.PlaceItemOnTile(mm.GetTileBehindSnakePart(snake.GetSnakePart(1)), snake.GetSnakePart(0));
            _ShouldGrow = false;
        }
    }
}
