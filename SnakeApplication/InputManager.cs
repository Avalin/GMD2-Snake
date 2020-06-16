using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SnakeApplication
{
    class InputManager
    {
        private readonly bool debug = false;

        private readonly GameStateManager gsm;
        private readonly List<Keys> input;

        public InputManager(GameStateManager gsm) 
        {
            this.gsm = gsm;
            input = new List<Keys>();
        }

        public void AddInput(KeyEventArgs e) 
        {
            input.Add(e.KeyCode);
        }

        public void ProcessInput()
        {
            if (debug) Console.WriteLine("Processing input...");
            List<Keys> tempInput = new List<Keys>(input);
            input.Clear();
            foreach (Keys key in tempInput)
            {
                switch (key)
                {
                    case Keys.Space:
                        if (debug) Console.WriteLine("Space is pressed");
                        if (GameState.Over != gsm.GetGameState()) gsm.PauseUnpauseGame();
                        break;

                    case Keys.W:
                        if (debug) Console.WriteLine("W is pressed");
                        if (GameState.Over != gsm.GetGameState()) ChangeSnakeDirection(Direction.Up);
                        break;

                    case Keys.A:
                        if (debug) Console.WriteLine("A is pressed");
                        if (GameState.Over != gsm.GetGameState()) ChangeSnakeDirection(Direction.Left);
                        break;

                    case Keys.S:
                        if (debug) Console.WriteLine("S is pressed");
                        if (GameState.Over != gsm.GetGameState()) ChangeSnakeDirection(Direction.Down);
                        break;

                    case Keys.D:
                        if (debug) Console.WriteLine("D is pressed");
                        if (GameState.Over != gsm.GetGameState()) ChangeSnakeDirection(Direction.Right);
                        break;

                    case Keys.R:
                        if (debug) Console.WriteLine("R is pressed");
                        Program.gw.Hide();
                        Program.gw = new GameWindow();
                        Program.gw.Show();
                        Program.gw.GameLoop();
                        break;
                }
            }
        }

        private void ChangeSnakeDirection(Direction newDirection)
        {
            SnakePart snakeHead = gsm.GetSnake().GetSnakeHead();
            if (newDirection != snakeHead.GetSnakeDirection().GetOppositeDirection())
            {
                snakeHead.SetSnakePartDirection(newDirection);
            }
        }
    }
}
