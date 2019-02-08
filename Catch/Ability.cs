using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catch
{
    class Ability // this class is all about altering
    {
        private int max; // maximum times ability can be used
        private int use; // the amount of times ability has been used

        private double gravity; // the altered value of gravity
        private double ySpeed; // the altered value of ySpeed
        private double xAcc; // etc
        private double xSpeed;

        public Ability(int max, double gravity, double ySpeed, double xAcc, double xSpeed)
        {
            this.max = max;
            use = max;

            this.gravity = gravity;
            this.ySpeed = ySpeed;
            this.xAcc = xAcc;
            this.xSpeed = xSpeed;
        }

        public int MsLockY(double fGravity, double fYSpeed) // millisecond lock on y (final values)
        {
            return (int)((fYSpeed - ySpeed) / ((fGravity + gravity) / 2));
        }
        public int MsLockX(double fXSpeed, double fXDist) // millisecond lock on x (final values)
        {
            return (int)( (2 * fXDist) / (Math.Abs(fXSpeed) + xSpeed));
        }

        public int Max { get => max; set => max = value; }
        public int Use { get => use; set => use = value; }

        public double Gravity { get => gravity; set => gravity = value; }
        public double YSpeed { get => ySpeed; set => ySpeed = value; }
        public double XAcc { get => xAcc; set => xAcc = value; }
        public double XSpeed { get => xSpeed; set => xSpeed = value; }
    }
}
