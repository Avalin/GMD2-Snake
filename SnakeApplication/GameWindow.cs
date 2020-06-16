using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeApplication
{
    public partial class GameWindow : Form
    {
        private bool debug = false;
        
        //Update
        private TimeSpan timeBuffer = new TimeSpan(0);
        
        //Render
        private Graphics gfx_details = null;
        private Graphics gfx_main = null;
        private Image bitmap = null;

        // MANAGERS
        MapManager mapManager;
        GameStateManager gameStateManager;
        InputManager inputManager;

        public GameWindow()
        {
            InitializeComponent();
            InitializeManagers();
            InitializeGraphics();
        }

        void InitializeManagers()
        {
            mapManager = new MapManager(32, 16, 10);
            gameStateManager = new GameStateManager(GameState.Playing, mapManager);
            inputManager = new InputManager(gameStateManager);
        }

        void InitializeGraphics() 
        {
            bitmap = new Bitmap(
                mapManager.GetTileSize() * mapManager.GetMapSize()[0],
                mapManager.GetTileSize() * mapManager.GetMapSize()[1]);
            gfx_main = PB_background.CreateGraphics();
            gfx_details = Graphics.FromImage(bitmap);
        }

        void ClearDrawSpace()
        {
            int[] xy = mapManager.GetMapSize();
            int tileSize = mapManager.GetTileSize();
            gfx_main.DrawImage(bitmap, 0, 0);
            gfx_details.FillRectangle(new SolidBrush(Color.LightBlue), 0, 0, tileSize * xy[0], tileSize * xy[1]);
        }

        #region Game Loop Methods
        internal void GameLoop()
        {
            TimeSpan MS_PER_FRAME = TimeSpan.FromMilliseconds(1.0 / 60.0 * 10000.0);
            Stopwatch stopwatch = Stopwatch.StartNew();
            TimeSpan previous = stopwatch.Elapsed;
            while (true)
            {
                TimeSpan current = stopwatch.Elapsed;
                TimeSpan deltaTime = current - previous;
                previous = current;
                timeBuffer += deltaTime;
                inputManager.ProcessInput();

                //Fixed timestep for logics, varying for rendering
                while (timeBuffer >= MS_PER_FRAME)
                {
                    if (gameStateManager.GetGameState() == GameState.Playing)
                    {
                        UpdateGameLogic();
                    }
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

        private void RenderToScreen(double interpolationAlpha)
        {
            if (debug) Console.WriteLine("Rendering to screen...");
            // Render position = previous position * interpolation alpha + current position * (1 - interpolation alpha)
            ClearDrawSpace();
            Draw();
            Application.DoEvents();
        }
        private void Draw() 
        {
            gameStateManager.Draw(mapManager, gfx_details);
        }

        private void UpdateGameLogic()
        {
            if (debug) Console.WriteLine("Updating game logic...");
            gameStateManager.GetSnake().Update(mapManager);
            gameStateManager.RefreshFood();
        }
        #endregion

        #region Form Events
        private void GameWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            inputManager.AddInput(e);
        }
        #endregion
    }
}
