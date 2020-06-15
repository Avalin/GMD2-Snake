using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApplication
{
    class GameStateManager
    {
        static int score = 0;
        public enum GameState
        {
            Playing,
            Pausing,
            Over
        }
        static GameState currentGameState;

        public GameStateManager(GameState currentState) 
        {
            currentGameState = currentState;
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
