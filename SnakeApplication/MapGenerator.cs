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
    }
    class MapGenerator
    {
        private bool debug;
        private int tileSize;
        private int mapSizeX;
        private int mapSizeY;
        LinkedList<Tile> tiles = new LinkedList<Tile>();

        MapGenerator(int tileSize, int mapSizeX, int mapSizeY) 
        {
            CreateRectangleMap(mapSizeX, mapSizeY);
            this.tileSize = tileSize;
        }
        MapGenerator(int tileSize, int mapSize)
        {
            CreateSquareMap(mapSize);
            this.tileSize = tileSize;
        }

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
                Y = y
            };
            tiles.AddLast(tile);
        }
        public int GetTileSize() 
        {
            return tileSize;
        }

        public void SetTileSize(int size)
        {
            tileSize = size;
        }
    }
}
