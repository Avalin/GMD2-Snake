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
        private TimeSpan lag = new TimeSpan(0);
        public GameWindow()
        {
            InitializeComponent();
            FoodGenerator fg = new FoodGenerator();
        }

        private void GameWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

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

                //ProcessInput();
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

        private void ProcessInput(object sender, KeyEventArgs e)
        {
            //Input events here
        }

        private void RenderToScreen()
        {
            //Render events here
            Application.DoEvents();
        }

        private void UpdateGameLogic()
        {

        }
    }
}
