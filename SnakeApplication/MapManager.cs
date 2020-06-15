using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApplication
{
    class MapManager
    {
        private readonly bool debug = false;

        private int tileSize;
        private int mapSizeX;
        private int mapSizeY;
        private LinkedList<Tile> tiles = new LinkedList<Tile>();

        #region Constructors
        public MapManager(int tileSize, int mapSizeX, int mapSizeY) 
        {
            CreateRectangleMap(mapSizeX, mapSizeY);
            this.tileSize = tileSize;
            
            #region Debug Tools
            if (debug) 
            {
                for (int i = 0; i < mapSizeX*mapSizeY; i++)
                {
                    Console.WriteLine("Tile at position " + tiles.ElementAt(i).X + ", " + tiles.ElementAt(i).Y + ".");
                }
                Console.WriteLine("There are " + tiles.Count() + " tiles in the list.");
            }
            #endregion
        }
        public MapManager(int tileSize, int mapSize)
        {
            CreateSquareMap(mapSize);
            this.tileSize = tileSize;

            #region Debug Tools
            if (debug)
            {
                for (int i = 0; i < mapSize * mapSize; i++)
                {
                    Console.WriteLine("Tile at position " + tiles.ElementAt(i).X + ", " + tiles.ElementAt(i).Y + ".");
                }
                Console.WriteLine("There are "+ tiles.Count()+ " tiles in the list.");
            }
            #endregion
        }
        #endregion

        #region Tile Get Methods
        public Tile GetCenterTile()
        {
            int centerX = mapSizeX / 2;
            int centerY = mapSizeY / 2;
            Tile foundTile = null;
            foreach (Tile tile in tiles)
            {
                if (tile.X == centerX && tile.Y == centerY)
                {
                    foundTile = tile;
                }
            }
            return foundTile;
        }

        public Tile GetRandomTile() 
        {
            var random = new Random();
            int range = random.Next(tiles.Count()-1);
            Tile randomTile = tiles.ElementAt(range);

            //If tile already holds something, find another
            if (randomTile.Item != null) GetRandomTile();
            return randomTile;
        }

        public Tile GetTileAtPosition(int x, int y)
        {
            Tile foundTile = tiles.First();
            foreach (Tile tile in tiles) 
            {
                if (tile.X == x && tile.Y == y) 
                {
                    foundTile = tile;
                }
            }
            return foundTile;
        }

        public Tile GetTileWithItem(TileItem item)
        {
            for (LinkedListNode<Tile> tileNode = tiles.First; tileNode != null; tileNode = tileNode.Next) 
            {
                if (item == tileNode.Value.Item)
                {
                    return tileNode.Value;
                }
            }
            return null;
        }

        public void PlaceItemOnTile(Tile tile, TileItem item)
        {
            for (LinkedListNode<Tile> tileNode = tiles.First; tileNode != null;)
            {
                if (tile.Equals(tileNode.Value))
                {
                    tileNode.Value.Item = item;
                    return;
                }
                tileNode = tileNode.Next;
            }

            throw new Exception("unable to place item on tile");
        }
        #endregion

        #region Get Neighbour Tiles
        public Tile FindLeftNeighbourToTile(Tile myTile)
        {
            //Avoid out of range and move to the other side
            int x = mod(myTile.X - 1, mapSizeX);
            return GetTileAtPosition(x, myTile.Y);
        }

        public Tile FindRightNeighbourToTile(Tile myTile)
        {
            //Avoid out of range and move to the other side
            int x = mod(myTile.X + 1, mapSizeX);
            return GetTileAtPosition(x, myTile.Y);
        }

        public Tile FindDownwardsNeighbourToTile(Tile myTile)
        {
            //Avoid out of range and move to the other side
            int y = mod(myTile.Y + 1, mapSizeY);
            return GetTileAtPosition(myTile.X, y);
        }

        public Tile FindUpwardsNeighbourToTile(Tile myTile)
        {
            //Avoid out of range and move to the other side
            int y = mod(myTile.Y - 1, mapSizeY);
            return GetTileAtPosition(myTile.X, y);
        }
        #endregion

        #region Create Tile Map
        void CreateSquareMap(int size) 
        {
            mapSizeX = size;
            mapSizeY = size;
            InitializeTiles(mapSizeX, mapSizeY);
        }

        void CreateRectangleMap(int sizeX, int sizeY)
        {
            mapSizeX = sizeX;
            mapSizeY = sizeY;
            InitializeTiles(mapSizeX, mapSizeY);
        }

        void InitializeTiles(int mapSizeX, int mapSizeY)
        {
            for (int x = 0; x < mapSizeX; x++)
            {
                for (int y = 0; y < mapSizeY; y++)
                {
                    CreateTile(x, y);
                }
            }
        }

        void CreateTile(int x, int y)
        {
            Tile tile = new Tile
            {
                X = x,
                Y = y,
                Item = null
            };
            tiles.AddLast(tile);
        }
        #endregion

        public int GetTileSize() 
        {
            return tileSize;
        }

        public int[] GetMapSize()
        {
            return new int[]{ mapSizeX, mapSizeY };
        }

        // Standard Modulus Operator
        int mod(int x, int m)
        {
            return (x % m + m) % m;
        }
    }
}
