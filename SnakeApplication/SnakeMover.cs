using System;
using System.Collections.Generic;

namespace SnakeApplication
{
    class SnakeMover
    {
        readonly Snake snake;

        public SnakeMover(Snake snake) 
        {
            this.snake = snake;
        }

        public bool ShouldGrow { get; set; }

        public void MoveSnakeParts(LinkedList<SnakePart> snakeParts, MapManager mm) 
        {
            LinkedListNode<SnakePart> snakeHead = snakeParts.Last;
            Tile destinationTile = mm.GetTileInFrontOfSnakePart(snakeHead.Value);
            Tile currentTile = mm.GetTileWithItem(snakeParts.First.Value);
            mm.PlaceItemOnTile(currentTile, null);

            for (LinkedListNode<SnakePart> snakePartNode = snakeParts.First; snakePartNode != null;)
            {
                LinkedListNode<SnakePart> nextSnakePartNode = snakePartNode.Next;
                if (nextSnakePartNode != null)
                {
                    // Move snakePart forward to take the tile of the next snakePart
                    MoveSnakePartToTileOfNextSnakePart(mm, snakePartNode.Value, nextSnakePartNode.Value);
                }
                else 
                {
                    //Moves snakehead to destination
                    MoveSnakeHeadToDestinationTile(mm, destinationTile, snakePartNode.Value);
                }
                snakePartNode = nextSnakePartNode;
            }
            if (ShouldGrow) GrowSnake(mm);
            HandleCollision(mm.GetTileInFrontOfSnakePart(snakeHead.Value));
        }

        void MoveSnakeHeadToDestinationTile(MapManager mm, Tile destinationTile, SnakePart snakeHead) 
        {
            if (destinationTile == null)
            {
                throw new Exception("destinationTile is null");
            }
            mm.PlaceItemOnTile(destinationTile, snakeHead);
        }

        void MoveSnakePartToTileOfNextSnakePart(MapManager mm, SnakePart snakePart, SnakePart nextSnakePart) 
        {
            Tile nextTile = mm.GetTileWithItem(nextSnakePart);
            if (nextTile == null)
            {
                throw new Exception("nextTile is null");
            }
            mm.PlaceItemOnTile(nextTile, snakePart);
            snakePart.SetSnakePartDirection(nextSnakePart.GetSnakeDirection().GetCurrentDirection());
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
            ShouldGrow = false;
        }
    }
}
