using System;
using System.Collections.Generic;
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
        private Image img = null;

        // GAME MANAGERS
        MapManager mapManager;
        GameStateManager gsm;
        InputManager im;

        public GameWindow()
        {
            InitializeComponent();
            InitializeManagers();
            InitializeGraphics();
        }

        void ClearDrawSpace()
        {
            int[] xy = mapManager.GetMapSize();
            int tileSize = mapManager.GetTileSize();
            gfx_main.DrawImage(img, 0, 0);
            gfx_details.FillRectangle(new SolidBrush(Color.LightBlue), 0, 0, tileSize * xy[0], tileSize * xy[1]);
        }

        void InitializeManagers()
        {
            mapManager = new MapManager(32, 16, 10);
            gsm = new GameStateManager(GameState.Playing, mapManager);
            im = new InputManager(gsm);
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
            while (true)
            {
                TimeSpan current = stopwatch.Elapsed;
                TimeSpan deltaTime = current - previous;
                previous = current;
                timeBuffer += deltaTime;
                im.ProcessInput();

                //Fixed timestep for logics, varying for rendering
                while (timeBuffer >= MS_PER_FRAME)
                {
                    if (gsm.GetGameState() == GameState.Playing)
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
            gsm.Draw(mapManager, gfx_details);
        }

        private void UpdateGameLogic()
        {
            if (debug) Console.WriteLine("Updating game logic...");
            gsm.GetSnake().Update(mapManager);
            gsm.RefreshFood();
        }
        #endregion

        #region Form Events
        private void GameWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            im.AddInput(e);
        }
        #endregion
    }
}
