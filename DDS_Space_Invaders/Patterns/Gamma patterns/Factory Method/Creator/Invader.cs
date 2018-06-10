using Invaders.Patterns.Gamma_patterns.Decorator;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Invaders.Factory
{
    abstract class Invader : IDecor
    {
        private const int horizontalInterval = 10;
        private const int verticalInterval = 30;

        public Bitmap image;
        private Bitmap[] imageArray;

        public Point Location { get; private set; }

        public ShipType InvaderType { get; private set; }

        public Rectangle Area
        {
            get
            {
                return new Rectangle(Location, imageArray[0].Size);
            }
        }

        public int Score { get; private set; }

        public Invader(ShipType invaderType, Point location, int score)
        {
            this.InvaderType = invaderType;
            this.Location = location;
            this.Score = score;

            createInvaderBitmapArray();
            image = imageArray[0];
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Right:
                    // Location is a struct, so new one created to keep it immutable
                    Location = new Point((Location.X + horizontalInterval), Location.Y);
                    break;
                case Direction.Left:
                    Location = new Point((Location.X - horizontalInterval), Location.Y);
                    break;
                case Direction.Down:
                    Location = new Point(Location.X, (Location.Y + verticalInterval));
                    break;
            }

        }
        public Graphics Draw(Graphics graphics, int animationCell)
        {
            Graphics invaderGraphics = graphics;
            {
                try
                {
                    graphics.DrawImage(image, Location);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            //DEBUG red square invaders
            //graphics.FillRectangle(Brushes.Red,
            //    Location.X, Location.Y, 20, 20);
            return invaderGraphics;
        }

        public void SetImage(Bitmap image)
        {
            this.image = image;
        }

        public virtual int AddAditionalScore(int score)
        {
            return score;
        }

        private void createInvaderBitmapArray()
        {
            imageArray = new Bitmap[1];
            switch (InvaderType)
            {
                case ShipType.Bug:
                    imageArray[0] = Properties.Resources.bug1;
                    break;
                case ShipType.Satellite:
                    imageArray[0] = Properties.Resources.satellite1;
                    break;
                case ShipType.Saucer:
                    imageArray[0] = Properties.Resources.flyingsaucer1;
                    break;
                case ShipType.Spaceship:
                    imageArray[0] = Properties.Resources.spaceship1;
                    break;
                case ShipType.Star:
                    imageArray[0] = Properties.Resources.star1;
                    break;
            }
        }
    }
}
