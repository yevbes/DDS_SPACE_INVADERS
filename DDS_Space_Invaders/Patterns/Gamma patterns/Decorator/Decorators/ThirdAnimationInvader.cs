using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Invaders.Factory;
using System.Windows.Forms;

namespace Invaders.Patterns.Gamma_patterns.Decorator.Decorators
{
    class ThirdAnimationInvader : InvaderDecorator
    {
        private Bitmap[] imageArray;
        private Invader inv;
        public ShipType InvaderType { get; private set; }

        public ThirdAnimationInvader(IDecor invader) : base(invader)
        {
            inv = invader as Invader;
            inv.SetImage(Properties.Resources.nullable);
        }

        public override Graphics Draw(Graphics graphics, int animationCell)
        {
            this.decoratedInvader.Draw(graphics, animationCell);
            return AnimateInvaders(graphics, animationCell);
        }

        private Graphics AnimateInvaders(Graphics graphics, int animationCell)
        {
            createInvaderBitmapArray();
            Graphics invaderGraphics = graphics;
            {
                try
                {
                    graphics.DrawImage(this.imageArray[animationCell], inv.Location);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return invaderGraphics;
        }

        private void createInvaderBitmapArray()
        {
            imageArray = new Bitmap[4];
            switch (inv.InvaderType)
            {
                case ShipType.Bug:
                    imageArray[0] = Properties.Resources.bug1;
                    imageArray[1] = Properties.Resources.bug2;
                    imageArray[2] = Properties.Resources.bug3;
                    imageArray[3] = Properties.Resources.bug4;
                    break;
                case ShipType.Satellite:
                    imageArray[0] = Properties.Resources.satellite1;
                    imageArray[1] = Properties.Resources.satellite2;
                    imageArray[2] = Properties.Resources.satellite3;
                    imageArray[3] = Properties.Resources.satellite4;
                    break;
                case ShipType.Saucer:
                    imageArray[0] = Properties.Resources.flyingsaucer1;
                    imageArray[1] = Properties.Resources.flyingsaucer2;
                    imageArray[2] = Properties.Resources.flyingsaucer3;
                    imageArray[3] = Properties.Resources.flyingsaucer4;
                    break;
                case ShipType.Spaceship:
                    imageArray[0] = Properties.Resources.spaceship1;
                    imageArray[1] = Properties.Resources.spaceship2;
                    imageArray[2] = Properties.Resources.spaceship3;
                    imageArray[3] = Properties.Resources.spaceship4;
                    break;
                case ShipType.Star:
                    imageArray[0] = Properties.Resources.star1;
                    imageArray[1] = Properties.Resources.star2;
                    imageArray[2] = Properties.Resources.star3;
                    imageArray[3] = Properties.Resources.star4;
                    break;
            }
        }
    }
}
