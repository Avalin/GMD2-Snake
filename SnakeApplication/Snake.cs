using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApplication
{
    class Snake : Drawable
    {
        private readonly bool debug = true;
        private readonly SnakeMover snakeMover;
        private int score;

        private LinkedList<SnakePart> snakeParts;

        public Snake(int length)
        {
            score = 0;
            snakeMover = new SnakeMover();
            snakeParts = new LinkedList<SnakePart>();

            for (int i = 0; i < length; i++) 
            {
                AddSnakePart();
            }
        }

        public int GetSnakeLength() 
        {
            return snakeParts.Count();
        }

        public SnakePart GetSnakeHead()
        {
            return snakeParts.ElementAt(snakeParts.Count-1);
        }

        public SnakePart GetSnakePart(int i)
        {
            return snakeParts.ElementAt(i);
        }

        public void AddSnakePart() 
        {
            if (snakeParts.Count() == 0)
            {
                snakeParts.AddFirst(new SnakePart());
                snakeParts.First.Value.SetSnakePartType(SnakePart.PartType.Head);
            }
            else 
            {
                snakeParts.AddFirst(new SnakePart());
                if (snakeParts.First.Next.Value.GetSnakePartType() == SnakePart.PartType.Tail) 
                {
                    snakeParts.First.Next.Value.SetSnakePartType(SnakePart.PartType.Body);
                }
            }
        }

        public void EatFood(Food food) 
        {
            score += food._Value;
            AddSnakePart();

            #region Debug Tools
            if (debug) 
            {
                Console.WriteLine("Snake ate " + food._FoodType + " for a value of " + food._Value + ".");
                Console.WriteLine("Snake now has a score of " + score + " and a length of " + snakeParts.Count() + ".");
            }
            #endregion Debug Tools
        }

        public void AddSnakeToMap(MapManager mm)
        {
            SnakePart snakeTail = snakeParts.First();
            mm.PlaceItemOnTile(mm.GetCenterTile(), snakeTail);
            Tile currentTile;

            for (LinkedListNode<SnakePart> spNode = snakeParts.First; spNode != null;) 
            {
                LinkedListNode<SnakePart> nextNode = spNode.Next;
                currentTile = mm.GetTileWithItem(spNode.Value);
                if (nextNode != null) 
                {
                    Tile tile = mm.FindLeftNeighbourToTile(currentTile);
                    if(tile == null) { throw new Exception("unable to find left neighbour tile"); }
                    mm.PlaceItemOnTile(tile, nextNode.Value);
                }
                spNode = nextNode;
            }
        }

        public void Update(MapManager mm) 
        {
            snakeMover.MoveSnakeParts(snakeParts, mm);
        }

        public void Draw(MapManager mm, Graphics gfx)
        {
            foreach (SnakePart sp in snakeParts) 
            {
                sp.Draw(mm, gfx);
            }
        }
    }
}
