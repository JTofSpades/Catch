using System;
using System.Drawing;

namespace Catch
{
    class Player
    {
        private bool inputLock;
        private int msLock;

        private Rectangle body;
        private string name;
        private Color col;
        private Point scoreLoc;
        private int score;

        private int jumpMax;
        private int jumpUse;

        private double defGravity; // default fall acceleration, read-only
        private double defXAcc; // default movement acceleration, read-only
        private double jumpSpeed; // default jump speed, read-only
        private double moveSpeed; // default move speed, read-only
        private double xSpeedCap; // max xSpeed, read-only

        private double gravity;
        private double ySpeed;
        private double xAcc;
        private double xSpeed;

        private Ability[] abilities;
        private bool rev; // reverse

        public Player(Rectangle body, string name, Color col, int jumpMax, double defGravity, double defXAcc, double jumpSpeed, double moveSpeed, double xSpeedCap)
        {
            inputLock = false;

            this.body = body;
            this.name = name;
            this.col = col;
            scoreLoc = new Point(body.Location.X, body.Location.Y + 50);
            score = 0;

            this.jumpMax = jumpMax;
            jumpUse = jumpMax;

            this.defGravity = defGravity;
            this.defXAcc = defXAcc;
            this.jumpSpeed = jumpSpeed;
            this.moveSpeed = moveSpeed;
            this.xSpeedCap = xSpeedCap;

            gravity = defGravity;
            ySpeed = 0;
            xAcc = 0;
            xSpeed = 0;

            Ability yDash = new Ability(1, defGravity, jumpSpeed * 5.2 / 3, 0, 0);
            Ability xDash = new Ability(2, 0, 0, xAcc * 5 / 3, moveSpeed * 4.25);
            Ability gFlip = new Ability(1, -defGravity, 0, xAcc, xSpeed);
            abilities = new Ability[] { yDash, xDash, gFlip };
            rev = false;
        }
        public void Update(Fruit f, int w, int h) // width and height of the window
        {
            LockInput();
            DetFruit(f, w, h);

            if (body.Bottom > h)
            {
                ySpeed = 0;
                body.Y = h - body.Height;

                if (!rev) { BorderHitY(); }
            }
            else if (body.Top < 0)
            {
                ySpeed = 0;
                body.Y = 0;

                if (rev) { BorderHitY(); }
            }
            else
            {
                ySpeed += gravity;
                body.Y += (int)ySpeed;
            }

            if (body.Left < 0)
            {
                body.X = 0;
                InvertX();
            }
            else if (body.Right > w)
            {
                body.X = w - body.Width;
                InvertX();
            }
            else
            {
                if (xAcc > 0) { xSpeed = xSpeed + xAcc > xSpeedCap ? xSpeedCap : xSpeed + xAcc; }
                else if (xAcc < 0) { xSpeed = xSpeed + xAcc < -xSpeedCap ? -xSpeedCap : xSpeed + xAcc; }
                body.X += (int)xSpeed;
            }
        }
        private void BorderHitY() // triggers if body hits a y border
        {
            jumpUse = jumpMax;

            abilities[0].Use = abilities[0].Max;
            abilities[1].Use = abilities[1].Max;
            abilities[2].Use = abilities[2].Max;
        }

        private void LockInput()
        {
            if (msLock > 0)
            {
                inputLock = true;
                msLock--;

                if (msLock <= 0)
                {
                    gravity = !rev ? defGravity : -defGravity;

                    if (xAcc > 0) { xAcc = defXAcc; }
                    else if (xAcc < 0) { xAcc = -defXAcc; }
                    if (xSpeed > 0) { xSpeed = xSpeedCap; }
                    else if (xSpeed < 0) { xSpeed = -xSpeedCap; }
                }
            }
            else { inputLock = false; }
        }

        private void DetFruit(Fruit f, int w, int h)
        {
            if (body.IntersectsWith(f.Rect))
            {
                score++;
                f.ChangeLoc(w, h);
            }
        }

        public void Jump()
        {
            if (jumpUse <= 0) { return; }
            jumpUse--;

            double diff = jumpUse == jumpMax - 1 ? 0 : (jumpMax - jumpUse) * .01 * jumpSpeed;

            gravity = !rev ? defGravity : -defGravity;
            ySpeed = !rev ? jumpSpeed - diff : -jumpSpeed - diff;
        }
        public void Move(bool pos) // positive (true) or negative (false)
        {
            if ( (pos && xAcc > 0) || (!pos && xAcc < 0)) { return; }

            xAcc = pos ? defXAcc : -defXAcc;
            xSpeed = pos ? moveSpeed : -moveSpeed;
        }

        public void InvertX()
        {
            xAcc *= -1;
            xSpeed *= -1;
        }
        public void StopX()
        {
            xAcc = 0;
            xSpeed = 0;
        }

        public void Ability0()
        {
            Ability a = abilities[0];
            if (a.Use <= 0) { return; }
            a.Use--;

            double diff = a.Use == a.Max - 1 ? 0 : (a.Max - a.Use) * .01 * jumpSpeed;

            gravity = !rev ? a.Gravity : -a.Gravity;
            ySpeed = !rev ? a.YSpeed - diff : -a.YSpeed - diff;
            xAcc = a.XAcc;
            xSpeed = a.XSpeed;

            msLock = a.MsLockY(gravity, 0);
        }
        public void Ability1()
        {
            Ability a = abilities[1];
            if (a.Use <= 0) { return; }
            a.Use--;

            gravity = !rev ? a.Gravity : -a.Gravity;
            ySpeed = !rev ? a.YSpeed : -a.YSpeed;
            xAcc = xAcc > 0 ? a.XAcc : -a.XAcc;
            xSpeed = xSpeed > 0 ? a.XSpeed : -a.XSpeed;

            msLock = a.MsLockX(xSpeed, 400);
        }
        public void Ability2()
        {
            Ability a = abilities[2];
            if (a.Use <= 0) { return; }
            a.Use--;

            gravity = a.Gravity;
            ySpeed = a.YSpeed;
            xAcc = a.XAcc;
            xSpeed = a.XSpeed;

            rev = !rev;
            a.Gravity *= -1;
        }

        public bool InputLock { get => inputLock; set => inputLock = value; }

        public Rectangle Body { get => body; set => body = value; }
        public Point Loc { get => body.Location; set => body.Location = value; }
        public Size Size { get => body.Size; set => body.Size = value; }
        public string Name { get => name; set => name = value; }
        public Color Col { get => col; set => col = value; }
        public Point ScoreLoc { get => scoreLoc; set => scoreLoc = value; }
        public int Score { get => score; set => score = value; }

        public int JumpMax { get => jumpMax; set => jumpMax = value; }
        public int JumpUse { get => jumpUse; set => jumpUse = value; }

        public double DefGravity { get => defGravity; }
        public double DefXAcc { get => defXAcc; }
        public double JumpSpeed { get => jumpSpeed; }
        public double MoveSpeed { get => moveSpeed; }
        public double XSpeedCap { get => xSpeedCap; }

        public double Gravity { get => gravity; set => gravity = value; }
        public double YSpeed { get => ySpeed; set => ySpeed = value; }
        public double XAcc { get => xAcc; set => xAcc = value; }
        public double XSpeed { get => xSpeed; set => xSpeed = value; }

        public Ability[] Abilities { get => abilities; set => abilities = value; }
    }
}