using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApplication
{
    class GameStateManager
    {
        static int score = 0;
        MapManager mm;
        FoodManager fm;
        Snake snake;
        Food food;
        public enum GameState
        {
            Playing,
            Pausing,
            Over
        }
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
        }

        public Snake GetSnake() 
        {
            return snake;
        }

        public Food GetFood()
        {
            RefreshFood();
            return food;
        }

        public void RefreshFood() 
        {
            if (food._IsEaten)
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
            currentGameState = GameStateManager.GameState.Over;
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
