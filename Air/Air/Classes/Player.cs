using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air
{
    class Player : GameObject
    {
        public Point offset = new Point(100, 50);
        public Point startPosition, endPosition, location;
        public DateTime startTime ,endTime;

        public int speed = 40;              // max speed is 30
        public int maxSpeed = 40;          // temp value
        public int msec;

        private double val, min;
        public double gravity = 2;          // please calculate this value
        public double airResistance = 2;    // bigger is slower
        public double slidingValue = 0;
        public double flightDistance;       // records variables

        public bool isFlying, isGrounded, isPicked;
        public bool gameStart = false;
        public bool canPickUp = false;

        public double slidingVelocity { set { slidingValue = value; } }

        public double airtankValue { set { val = value; } }

        public double airtankMin { set { min = value; } }

        public Player(Bitmap bitmap, Point location) : base(bitmap)
        {
            this.image = bitmap;
            this.location = location;
        }

        public override void update(Point location, int msec)
        {
            this.msec = msec;

            if (gameStart)
            {
                if (this.location.X > 150)            // dont use magic number
                    this.location = new Point(this.location.X - (speed / 2), this.location.Y);

                else if (this.location.X < 150)       // dont use magic number
                    this.location = new Point(150, this.location.Y);


                if (isFlying && val > min)
                    this.location.Y -= (int)((gravity + (int)(gravity / 2)) * msec);

                else
                    this.location.Y += (int)((gravity) * msec);

                flightDistance += 0.01;     // calculate this value please
            }

            base.update(this.location, this.msec);
        }

        public void pickUp(Point mouseLocation)
        {
            if (!isGrounded)
            {
                this.location.Y += (int)((gravity) * msec);        // set this value please :(
            }

            if (this.location.Y > 720 - 150)            // this is onGround value
            {
                isGrounded = true;
                canPickUp = isGrounded ? true : false;
            }

            if (canPickUp)
            {
                if (isPicked)
                {
                    this.location = new Point(mouseLocation.X - (offset.X / 2), mouseLocation.Y - (offset.Y / 2));
                }
            }
        }

        public int velocity()
        {
            Point velocity = new Point(endPosition.X - startPosition.X, endPosition.Y - startPosition.Y);
            return (int)(Math.Pow(Math.Pow(velocity.X, 2) + Math.Pow(velocity.Y, 2), 0.5)) / (int)((endTime - startTime).TotalMilliseconds / 10);
        }
    }
}
