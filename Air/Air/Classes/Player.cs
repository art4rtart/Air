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
        private const int playerX = 150;
        public Point offset = new Point(100, 50);
        public Point startPosition, endPosition, location, initLocation;
        public DateTime startTime ,endTime;

        public double speed;              // max speed is 30
        public int minSpeed = 100;          // temp value
        public int msec;
        private int boostSpeed = 5;         // 10 is max value

        private double val, min;
        public double gravity = 2;          // please calculate this value
        public double airResistance = 1;    // bigger is slower
        public double slidingValue = 0;
        public double flightDistance;       // records variables

        public bool isFlying, isGrounded, isPicked;
        public bool gameStart = false;
        public bool canPickUp = false;
        public bool temp = false;
        private bool startTimer = true;

        public double slidingVelocity { set { slidingValue = value; } }

        public double airtankValue { set { val = value; } get { return val; } }

        public double airtankMin { set { min = value; } }

        public override RectangleF collisionBounds
        {
            get
            {
                RectangleF rect = this.rect;
                rect.Inflate(0, 10);
                return rect;
            }
        }

        public Player(Bitmap bitmap, Point location) : base(bitmap)
        {
            this.image = bitmap;
            this.location = location;
            this.initLocation = this.location;
        }

        public void init()
        {
            this.location = initLocation;

            speed = 0;              // max speed is 30
            minSpeed = 100;          // temp value
            boostSpeed = 5;         // 10 is max value

            val = 0; min = 0;
            gravity = 2;          // please calculate this value
            airResistance = 20;    // bigger is slower
            slidingValue = 0;
            flightDistance = 0;       // records variables

            isFlying = false; isGrounded = false; isPicked = false; gameStart = false; canPickUp = false;
            startTimer = true;
        }

        public void update(int msec)
        {
            rect.X = this.location.X;
            rect.Y = this.location.Y;
            this.msec = msec;

            if (gameStart)
            {
                TimeSpan gameTime = DateTime.Now - startTime;

                if (startTimer)
                {
                    startTime = DateTime.Now;
                    startTimer = false;
                }

                if (this.location.X > playerX)
                {
                    this.location.X -= (int)(airResistance / 2);
                    if(this.location.Y > 100)
                        this.location.Y -= (int)gravity;
                    airResistance += 0.5;
                }

                else if (this.location.X < playerX)
                {
                    this.location.X = playerX;
                    temp = true;
                }

                if (isFlying && val > min)
                {
                    this.speed += boostSpeed;
                    this.location.Y -= (int)((gravity + (int)(gravity / 2)) * msec);
                }

                else
                {
                    if(speed > minSpeed)
                        this.speed -= boostSpeed;

                    this.location.Y += (int)((gravity) * msec);
                }

                flightDistance += (speed * gameTime.TotalSeconds) / 10000;     // calculate this value please
            }
        }

        public void pickUp(Point mouseLocation)
        {
            if (!isGrounded)
            {
                this.location.Y += (int)((gravity + 5) * msec);        // set this value please :(
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
            return (int)(Math.Pow(Math.Pow(velocity.X, 2) + Math.Pow(velocity.Y, 2), 0.5)) / 2;
        }

        public void checkCollision(List<AnimObject> objects, Item item)
        {
            foreach (AnimObject obj in objects)
            {
                if (obj.tagName == "PineWheel")
                {
                    if (obj.collides(this))
                    {
                        item.effect = true;
                    }
                }

                else if (obj.tagName == "Star")
                {
                    if (obj.collides(this))
                    {
                        item.count++;
                        item.playSound();
                        item.startTimer = true;
                        
                        objects.Remove(obj);
                        return;
                    }
                }

                else if (obj.tagName == "AirUp")
                {
                    if (obj.collides(this))
                    {
                        item.effect = true;
                        item.playSound();
                        item.startTimer = true;

                        objects.Remove(obj);
                        return;
                    }
                }

                else if (obj.tagName == "AirDown")
                {
                    if (obj.collides(this))
                    {
                        item.effect = true;
                        item.playSound();
                        item.startTimer = true;

                        objects.Remove(obj);
                        return;
                    }
                }
            }
        }
    }
}
