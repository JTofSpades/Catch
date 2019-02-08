using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catch
{
    class Fruit
    {
        private static Size size = new Size(20, 20);

        private Rectangle rect;
        private Point loc;
        private Color col;

        public Fruit(Point loc, Color col)
        {
            this.loc = loc;
            rect = new Rectangle(loc, size);
            this.col = col;
        }

        public void ChangeLoc(int w, int h)
        {
            Random random = new Random();
            loc.X = (int)((w - size.Width) * random.NextDouble());
            loc.Y = (int)((h - size.Height) * random.NextDouble());

            int r = (int)(205 * random.NextDouble());
            int g = (int)(205 * random.NextDouble());
            int b = (int)(205 * random.NextDouble());

            col = Color.FromArgb(r, g, b);
            rect = new Rectangle(loc, size);
        }

        public static Size Size { get => size; }
        public Rectangle Rect { get => rect; set => rect = value; }
        public Point Loc { get => loc; set => loc = value; }
        public Color Col { get => col; set => col = value; }
    }
}