using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApplication
{
    class SnakeMover
    {
        public void MoveSnakeParts(LinkedList<SnakePart> snakeParts, MapManager mm) 
        {
            LinkedListNode<SnakePart> snakeHead = snakeParts.Last;
            Tile destinationTile = FindDestinationTile(mm, snakeHead.Value);
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
                    currentTile = nextTile;
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
        }

        Tile FindDestinationTile(MapManager mm, SnakePart snakeHead) 
        {
            Console.WriteLine("Penis " + snakeHead.GetSnakeDirection().GetCurrentDirection());
            switch (snakeHead.GetSnakeDirection().GetCurrentDirection()) 
            {
                case SnakeDirection.Direction.Up:
                    return mm.FindUpwardsNeighbourToTile(mm.GetTileWithItem(snakeHead));

                case SnakeDirection.Direction.Down:
                    return mm.FindDownwardsNeighbourToTile(mm.GetTileWithItem(snakeHead));

                case SnakeDirection.Direction.Left:
                    return mm.FindLeftNeighbourToTile(mm.GetTileWithItem(snakeHead));

                case SnakeDirection.Direction.Right:
                    return mm.FindRightNeighbourToTile(mm.GetTileWithItem(snakeHead));

                default:
                    return mm.FindLeftNeighbourToTile(mm.GetTileWithItem(snakeHead));
            }
        }
    }
}
