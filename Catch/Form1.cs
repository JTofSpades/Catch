using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catch
{
    public partial class Form1 : Form
    {
        Graphics g;
        Timer t;
        int floor;

        Size s;
        Player p1;
        Player p2;
        Fruit fruit;
        Font font;

        public Form1()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
            Width = 1500;
            Height = 900;
            floor = 700;

            t = new Timer();
            t.Start();
            t.Enabled = true;
            t.Interval = 10;
            t.Tick += T_Tick;

            s = new Size(30, 30);
            Point pt1 = new Point((Width - s.Width) / 3, floor - s.Height);
            Point pt2 = new Point((Width - s.Width) / 3 * 2, floor - s.Height);


            // CHOOSE HERE
            p1 = ChoosePlayer(7, "P1", pt1, Color.Violet);
            p2 = ChoosePlayer(8, "P2", pt2, Color.Brown);
            // CHOOSE HERE


            fruit = new Fruit(new Point((Width - Fruit.Size.Width) / 2, (Height - Fruit.Size.Height) / 2), Color.Purple);
            font = new Font("F", 30);
        }

        private Player ChoosePlayer(int opt, string n, Point startLoc, Color col)
        {
            switch (opt)
            {
                case 1: return new Player(new Rectangle(startLoc, s), n, col, 1, .8, .1, -12, 2.5, 5.85); // kinda slow, but kinda high jump
                case 2: return new Player(new Rectangle(startLoc, s), n, col, 1, .8, .15, -11, 3, 7); // kinda fast, but kinda short jump
                case 3: return new Player(new Rectangle(startLoc, s), n, col, 3, .8, .09, -13, 2, 4); // much slower, but more jump capabilities than avg
                case 4:                                                                                // more speed capabilities, but short jump
                    Player p1 = new Player(new Rectangle(startLoc, s), n, col, 1, .8, .25, -8.22, 3.95, 9);
                    p1.Abilities[1].Max = 3;
                    return p1;
                case 5:                                                                                // slow, short jump, all about gravity reversing
                    Player p2 = new Player(new Rectangle(startLoc, s), n, col, 1, .8, .095, -9.25, 2.1, 4.5);
                    p2.Abilities[2].Max = 3;
                    return p2;
                case 6:                                                                                 // fast, more jump capabilities, cannot change gravity
                    Player p3 = new Player(new Rectangle(startLoc, s), n, col, 2, .8, .2, -12.55, 3.25, 7.5);
                    p3.Abilities[0].Max = 2;
                    p3.Abilities[2].Max = 0;
                    return p3;
                case 7:                                                                                 // BROKEN
                    Player p4 = new Player(new Rectangle(startLoc, s), n, col, 5, .8, .35, -18.5, 5, 13);
                    p4.Abilities[0].Max = 7;
                    p4.Abilities[1].Max = 7;
                    p4.Abilities[2].Max = 7;
                    return p4;
                case 8:;                                                                               // BROKEN
                    Player p5 = new Player(new Rectangle(startLoc, s), n, col, 1, .8, .02, -5.8, 1.25, 2);
                    p5.Abilities[0].Max = 0;
                    p5.Abilities[1].Max = 0;
                    return p5;
            }


            return null;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.DrawLine(Pens.Black, 0, floor, Width, floor);

            g.FillRectangle(new SolidBrush(p1.Col), p1.Body);
            g.DrawString(p1.Name + " : " + p1.Score.ToString(), font, new SolidBrush(p1.Col), p1.ScoreLoc);
            g.FillRectangle(new SolidBrush(p2.Col), p2.Body);
            g.DrawString(p2.Name + " : " + p2.Score.ToString(), font, new SolidBrush(p2.Col), p2.ScoreLoc);

            g.FillEllipse(new SolidBrush(fruit.Col), fruit.Rect);
        }

        private void T_Tick(object sender, EventArgs e)
        {
            p1.Update(fruit, Width - s.Width / 2, floor);
            p2.Update(fruit, Width - s.Width / 2, floor);
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!p1.InputLock)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        p1.Jump();
                        break;
                    case Keys.A:
                        p1.Move(false);
                        break;
                    case Keys.S:
                        p1.StopX();
                        break;
                    case Keys.D:
                        p1.Move(true);
                        break;
                        
                    case Keys.D1:
                        p1.Ability0();
                        break;
                    case Keys.D2:
                        p1.Ability1();
                        break;
                    case Keys.D3:
                        p1.Ability2();
                        break;
                }
            }
            if (!p2.InputLock)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        p2.Jump();
                        break;
                    case Keys.Left:
                        p2.Move(false);
                        break;
                    case Keys.Down:
                        p2.StopX();
                        break;
                    case Keys.Right:
                        p2.Move(true);
                        break;

                    case Keys.H:
                        p2.Ability0();
                        break;
                    case Keys.J:
                        p2.Ability1();
                        break;
                    case Keys.K:
                        p2.Ability2();
                        break;
                }
            }
        }

        private void Form1_KeyPress(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
