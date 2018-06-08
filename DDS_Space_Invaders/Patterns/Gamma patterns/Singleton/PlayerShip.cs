using System;
using System.Drawing;

namespace Invaders
{
    class PlayerShip
    {
        private const int horizontalInterval = 10;
        public Point Location { get; private set; }
        public Rectangle Area
        {
            get
            {
                return new Rectangle(Location, image.Size);
            }
        }
        public Bitmap image = Properties.Resources.player;

        private DateTime deathWait;

        private bool alive;
        public bool Alive
        {
            get { return alive; }
            set
            {
                alive = value;
                if (!value)
                    deathWait = DateTime.Now;
            }
        }
        
        private Rectangle boundaries;

        private float deadShipHeight;

        #region
        /// <summary>
        ///  Singleton
        /// </summary>
        private static PlayerShip instance = null;

        private PlayerShip() { }

        public static PlayerShip Instance
        {
            get
            {
                if (instance == null)
                    instance = new PlayerShip();
                return instance;
            }
        }
        #endregion

        /*public PlayerShip(Rectangle boundaries, Point location)
        {
        this.boundaries = boundaries;
        this.Location = location;
        Alive = true;
        deadShipHeight = 1.0F;
        }*/

        public void InitValues(Rectangle boundaries, Point location)
        {
            this.boundaries = boundaries;
            this.Location = location;
            Alive = true;
            deadShipHeight = 1.0F;
        }

        public void Move(Direction direction)
        {
            if (Alive)
            {
                if (direction == Direction.Left)
                {
                    Point newLocation = new Point((Location.X - horizontalInterval), Location.Y);
                    if ((newLocation.X < (boundaries.Width - 100)) && (newLocation.X > 50))
                        Location = newLocation;
                }
                else if (direction == Direction.Right)
                {
                    Point newLocation = new Point((Location.X + horizontalInterval), Location.Y);
                    if ((newLocation.X < (boundaries.Width - 100)) && (newLocation.X > 50))
                        Location = newLocation;
                }
            }
        }

        public void Draw(Graphics graphics)
        {
            if (!Alive)
            {
                if ((DateTime.Now - deathWait) > TimeSpan.FromSeconds(1.5))
                {
                    deadShipHeight = 0.0F;
                    Alive = true;
                }
                else if ((DateTime.Now - deathWait) > TimeSpan.FromSeconds(1))
                {
                    deadShipHeight = 0.25F;
                }
                else if ((DateTime.Now - deathWait) > TimeSpan.FromSeconds(0.5))
                {
                    deadShipHeight = 0.75F;
                }
                else if ((DateTime.Now - deathWait) > TimeSpan.FromSeconds(0))
                {
                    deadShipHeight = 0.9F;
                }

                graphics.DrawImage(image, (float)Location.X, (float)Location.Y,
                        (float)image.Width, (image.Height * deadShipHeight));

            }
            else
            {
                graphics.DrawImage(image, Location);
            }
        }
    }
}
