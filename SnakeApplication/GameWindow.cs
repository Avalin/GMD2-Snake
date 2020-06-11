using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeApplication
{
    public partial class GameWindow : Form
    {
        private bool debug = true;
        private TimeSpan lag = new TimeSpan(0);
        private readonly List<Keys> input = new List<Keys>();

        // GAME MANAGERS
        FoodManager foodManager;
        MapManager mapManager;
        GameStateManager gsm;

        public GameWindow()
        {
            InitializeComponent();
            GameManagers();
        }

        void GameManagers() 
        {
            gsm = new GameStateManager(GameStateManager.GameState.Playing);
            foodManager = new FoodManager();
            mapManager = new MapManager(10, 10);
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
                TimeSpan elapsed = current - previous;
                previous = current;
                lag += elapsed;
                ProcessInput();
                
                //Fixed timestep for logics, varying for rendering
                while (lag >= MS_PER_FRAME)
                {
                    UpdateGameLogic();
                    lag -= MS_PER_FRAME;
                }
                Interpolate(stopwatch, previous);
                RenderToScreen();
                Refresh();
            }
        }

        private void Interpolate(Stopwatch s, TimeSpan previous)
        {
            //To avoid choppy rendering
            lag += s.Elapsed - previous; 
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
                        //Pause game
                        if (debug) Console.WriteLine("Space is pressed");
                        gsm.PauseUnpauseGame();
                        break;

                    case Keys.W:
                        if(debug) Console.WriteLine("W is pressed");
                        break;

                    case Keys.A:
                        if (debug) Console.WriteLine("A is pressed");
                        break;

                    case Keys.S:
                        if (debug) Console.WriteLine("S is pressed");
                        break;

                    case Keys.D:
                        if (debug) Console.WriteLine("D is pressed");
                        break;
                }
            }
        }

        private void RenderToScreen()
        {
            if (debug) Console.WriteLine("Rendering to screen...");
            Application.DoEvents();
        }
        private void UpdateGameLogic()
        {
            if (debug) Console.WriteLine("Updating game logic...");
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
