using System;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeApplication
{
    class RenderManager
    {
        private readonly bool debug = false;

        private Graphics gfx_details = null;
        private Graphics gfx_main = null;
        private Image bitmap = null;
        private MapManager mm;
        private GameStateManager gsm;

        public RenderManager(GameStateManager gsm, MapManager mm, Graphics gfx_main) 
        {
            this.gsm = gsm;
            this.mm = mm;
            this.gfx_main = gfx_main;
            InitializeGraphics();
        }

        public void RenderToScreen(double interpolationAlpha)
        {
            if (debug) Console.WriteLine("Rendering to screen...");
            // Render position = previous position * interpolation alpha + current position * (1 - interpolation alpha)
            ClearDrawSpace();
            Draw();
            Application.DoEvents();
        }

        private void InitializeGraphics()
        {
            bitmap = new Bitmap(
                mm.GetTileSize() * mm.GetMapSize()[0],
                mm.GetTileSize() * mm.GetMapSize()[1]);
            gfx_details = Graphics.FromImage(bitmap);
        }

        private void ClearDrawSpace()
        {
            int[] xy = mm.GetMapSize();
            int tileSize = mm.GetTileSize();
            gfx_main.DrawImage(bitmap, 0, 0);
            gfx_details.FillRectangle(new SolidBrush(Color.LightBlue), 0, 0, tileSize * xy[0], tileSize * xy[1]);
        }

        private void Draw()
        {
            gsm.Draw(mm, gfx_details);
        }
    }
}
