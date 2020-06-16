using System;
using System.Windows.Forms;

namespace SnakeApplication
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GameWindow gw = new GameWindow();
            gw.Show();
            gw.GameLoop();
        }

        // Standard Modulus Operator
        public static int mod(int x, int m)
        {
            return (x % m + m) % m;
        }
    }
}
