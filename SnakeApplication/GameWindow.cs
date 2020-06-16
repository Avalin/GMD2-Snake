using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SnakeApplication
{
    public partial class GameWindow : Form
    {
        private readonly bool debug = false;

        //Update
        private TimeSpan timeBuffer = new TimeSpan(0);

        // MANAGERS
        MapManager mapManager;
        GameStateManager gameStateManager;
        InputManager inputManager;
        RenderManager renderManager;

        public GameWindow()
        {
            InitializeComponent();
            InitializeManagers();
        }

        void InitializeManagers()
        {
            mapManager = new MapManager(32, 16, 10);
            gameStateManager = new GameStateManager(GameState.Playing, mapManager);
            inputManager = new InputManager(gameStateManager);
            renderManager = new RenderManager(gameStateManager, mapManager, PB_background.CreateGraphics());
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

                //Fixed timestep for logics
                while (timeBuffer >= MS_PER_FRAME)
                {
                    if (gameStateManager.GetGameState() == GameState.Playing)
                    {
                        UpdateGameLogic();
                    }
                    timeBuffer -= MS_PER_FRAME;
                }
                //Variable timestep for rendering
                renderManager.RenderToScreen(CalculateInterpolationAlpha(timeBuffer, MS_PER_FRAME));
            }
        }

        private double CalculateInterpolationAlpha(TimeSpan timeBuffer, TimeSpan MS_PER_FRAME)
        {
            //To avoid choppy rendering
            return timeBuffer.TotalMilliseconds / MS_PER_FRAME.TotalMilliseconds;
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
