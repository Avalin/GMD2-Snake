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

        public void SetGameState(GameState gs) 
        {
            currentGameState = gs;
        }

        public GameState GetGameState()
        {
            return currentGameState;
        }
    }
}
