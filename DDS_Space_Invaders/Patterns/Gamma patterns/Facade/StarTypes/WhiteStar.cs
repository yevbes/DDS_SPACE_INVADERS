using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Invaders.Patterns.Gamma_patterns.Facade
{
    class WhiteStar : Star
    {

        private Rectangle formArea;
        public WhiteStar(Random random, Rectangle formArea) : base(random, formArea)
        {
            this.formArea = formArea;
            for (int i = 1; i < 100; i++)
                addStar(random);
        }

        private void addStar(Random random)
        {
            int height = formArea.Height;
            int width = formArea.Width;
            Point location = new Point(random.Next(0, width), random.Next(0, height));
            ShapeStar newStar = new ShapeStar(location, Brushes.White);
            Stars.Add(newStar);
        }

        public override void Twinkle(Random random)
        {
            // Remove 4 stars and randomly place 4 new ones
            Stars.RemoveRange(0, 4);
            for (int i = 0; i < 4; i++)
                addStar(random);
        }
    }
}
