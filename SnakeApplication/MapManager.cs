using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApplication
{
    struct Tile
    {
        public int X;
        public int Y;
        public TileItem Item;
    }
    class MapManager
    {
        private bool debug = false;

        private int tileSize;
        private int mapSizeX;
        private int mapSizeY;
        LinkedList<Tile> tiles = new LinkedList<Tile>();
        
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

        #region Tile Get Methods
        public Tile GetCenterTile()
        {
            int centerPoint = tiles.Count() / 2;
            return tiles.ElementAt(centerPoint);
        }

        public Tile GetRandomTile() 
        {
            var random = new Random();
            int range = random.Next(tiles.Count());
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
            foreach (Tile tile in tiles)
            {
                if (tile.Item == item)
                {
                    return tile;
                }
            }
            return new Tile();
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
    }
}
