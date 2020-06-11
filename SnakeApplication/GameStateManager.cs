using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApplication
{
    class GameStateManager
    {
        public enum GameState
        {
            Playing,
            Pausing,
            Over
        }
        GameState currentGameState;

        public GameStateManager(GameState currentState) 
        {
            currentGameState = currentState;
        }

        public GameState GetGameState()
        {
            return currentGameState;
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
