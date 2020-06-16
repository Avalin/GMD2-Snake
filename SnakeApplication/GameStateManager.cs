using System.Drawing;

namespace SnakeApplication
{
    class GameStateManager
    {
        static int score = 0;
        MapManager mm;
        FoodManager fm;
        Snake snake;
        Food food;
        static GameState currentGameState;

        public GameStateManager(GameState currentState, MapManager mm)
        {
            currentGameState = currentState;
            this.mm = mm;
            snake = new Snake(4);
            snake.AddSnakeToMap(mm);
            this.fm = new FoodManager(snake);
            food = fm.SpawnFoodOnTile(mm);
        }

        public void Draw(MapManager mm, Graphics gfx)
        {
            GetSnake().Draw(mm, gfx);
            GetFood().Draw(mm, gfx);
            DrawUI(mm, gfx);
        }

        private void DrawUI(MapManager mm, Graphics gfx)
        {
            Tile center = mm.GetCenterTile();
            int tileSize = mm.GetTileSize();
            gfx.DrawString("Food eaten: " + score.ToString(), new Font("Arial", 10), new SolidBrush(Color.Black), center.X * tileSize, 0);
            if (GetGameState() == GameState.Over)
            {
                gfx.DrawString("GAME OVER", new Font("Arial", 20), new SolidBrush(Color.Black), center.X*tileSize, center.Y * tileSize);
            }

            if (GetGameState() == GameState.Pausing)
            {
                gfx.DrawString("PAUSED", new Font("Arial", 20), new SolidBrush(Color.Black), center.X * tileSize, center.Y * tileSize);
            }
        }

        public Snake GetSnake() 
        {
            return snake;
        }

        public Food GetFood()
        {
            return food;
        }

        public void RefreshFood() 
        {
            if (food.MIsEaten)
            {
                food = fm.SpawnFoodOnTile(mm);
            }
        }

        public FoodManager GetFoodManager()
        {
            return fm;
        }

        public static void AddPointsToScore(int points) 
        {
            score+=points;
        }

        public static void ResetScore()
        {
            score = 0;
        }

        public static int GetScore()
        {
            return score;
        }

        public GameState GetGameState()
        {
            return currentGameState;
        }

        public static void EndGame()
        {
            currentGameState = GameState.Over;
        }

        public void PauseUnpauseGame() 
        {
            if (currentGameState == GameState.Playing)
                currentGameState = GameState.Pausing;
            else if (currentGameState == GameState.Pausing)
                currentGameState = GameState.Playing;
        }
    }
}
