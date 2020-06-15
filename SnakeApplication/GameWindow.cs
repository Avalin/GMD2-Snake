using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeApplication
{
    public partial class GameWindow : Form
    {
        private bool debug = true;
        
        //Update
        private TimeSpan timeBuffer = new TimeSpan(0);
        
        //Input
        private readonly List<Keys> input = new List<Keys>();
        
        //Render
        private List<Drawable> drawables = new List<Drawable>();
        private Graphics gfx_details = null;
        private Graphics gfx_main = null;
        private Image img = null;

        // GAME MANAGERS
        FoodManager foodManager;
        MapManager mapManager;
        GameStateManager gsm;

        //Game Items
        Snake snake;
        Food food;


        public GameWindow()
        {
            InitializeComponent();
            GameManagers();
            InitializeGraphics();

            snake = new Snake(4);
            snake.AddSnakeToMap(mapManager);
            food = foodManager.SpawnFoodOnTile(mapManager);
        }

        void ClearDrawSpace()
        {
            int[] xy = mapManager.GetMapSize();
            int tileSize = mapManager.GetTileSize();
            gfx_details.FillRectangle(new SolidBrush(Color.LightBlue), 0, 0, tileSize * xy[0], tileSize * xy[1]);
        }

        void GameManagers()
        {
            gsm = new GameStateManager(GameStateManager.GameState.Playing);
            foodManager = new FoodManager();
            mapManager = new MapManager(32, 16, 10);
        }

        void InitializeGraphics() 
        {
            img = new Bitmap(
                mapManager.GetTileSize() * mapManager.GetMapSize()[0],
                mapManager.GetTileSize() * mapManager.GetMapSize()[1]);
            gfx_main = PB_background.CreateGraphics();
            gfx_details = Graphics.FromImage(img);
        }

        #region Game Loop Methods
        internal void GameLoop()
        {
            TimeSpan MS_PER_FRAME = TimeSpan.FromMilliseconds(1.0 / 60.0 * 10000.0);
            Stopwatch stopwatch = Stopwatch.StartNew();
            TimeSpan previous = stopwatch.Elapsed;
            while (gsm.GetGameState() != GameStateManager.GameState.Over)
            {
                TimeSpan current = stopwatch.Elapsed;
                TimeSpan deltaTime = current - previous;
                previous = current;
                timeBuffer += deltaTime;
                ProcessInput();
                
                //Fixed timestep for logics, varying for rendering
                while (timeBuffer >= MS_PER_FRAME)
                {
                    UpdateGameLogic();
                    timeBuffer -= MS_PER_FRAME;
                }
                RenderToScreen(CalculateInterpolationAlpha(timeBuffer, MS_PER_FRAME));
            }
        }

        private double CalculateInterpolationAlpha(TimeSpan timeBuffer, TimeSpan MS_PER_FRAME)
        {
            //To avoid choppy rendering
            return timeBuffer.TotalMilliseconds / MS_PER_FRAME.TotalMilliseconds;
        }

        private void ProcessInput()
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
                        gsm.PauseUnpauseGame();
                        break;

                    case Keys.W:
                        if(debug) Console.WriteLine("W is pressed");
                        ChangeSnakeDirection(SnakeDirection.Direction.Up, SnakeDirection.Direction.Down);
                        break;

                    case Keys.A:
                        if (debug) Console.WriteLine("A is pressed");
                        ChangeSnakeDirection(SnakeDirection.Direction.Left, SnakeDirection.Direction.Right);
                        break;

                    case Keys.S:
                        if (debug) Console.WriteLine("S is pressed");
                        ChangeSnakeDirection(SnakeDirection.Direction.Down, SnakeDirection.Direction.Up);
                        break;

                    case Keys.D:
                        if (debug) Console.WriteLine("D is pressed");
                        ChangeSnakeDirection(SnakeDirection.Direction.Right, SnakeDirection.Direction.Left);
                        break;
                }
            }
        }

        private void ChangeSnakeDirection(SnakeDirection.Direction newDirection, SnakeDirection.Direction oppositeDirection) 
        {
            if (snake.GetSnakeHead().GetSnakeDirection().GetCurrentDirection() != oppositeDirection)
            {
                snake.GetSnakeHead().GetSnakeDirection().SetCurrentDirection(newDirection);
            }
        }

        private void RenderToScreen(double interpolationAlpha)
        {
            if (debug) Console.WriteLine("Rendering to screen...");
            // Render position = previous position * interpolation alpha + current position * (1 - interpolation alpha)
            ClearDrawSpace();

            DrawDrawables();
            gfx_main.DrawImage(img, 0, 0);
            Application.DoEvents();
        }
        void DrawDrawables() 
        {
            //gfx_details.DrawImage(Properties.Resources.SnakeBody, 0, 0, 32, 32);
            snake.Draw(mapManager, gfx_details);
            food.Draw(mapManager, gfx_details);
        }

        private void UpdateGameLogic()
        {
            if (debug) Console.WriteLine("Updating game logic...");
            snake.Update(mapManager);
        }
        #endregion

        #region Form Events
        private void GameWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            input.Add(e.KeyCode);
        }
        #endregion
    }
}
