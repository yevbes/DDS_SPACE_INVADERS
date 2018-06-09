using System;
using System.Collections.Generic;
using System.Drawing;

namespace Invaders.Patterns.Gamma_patterns.Facade
{
    abstract class Star : IShape
    {
        private Rectangle formArea;
        private List<ShapeStar> stars;

        public Star(Random random, Rectangle formArea)
        {
            this.stars = new List<ShapeStar>();
            this.formArea = formArea;
        }

        internal List<ShapeStar> Stars { get => stars; set => stars = value; }

        public Graphics Draw(Graphics graphics)
        {
            Graphics starGraphics = graphics;
            foreach (ShapeStar Star in Stars)
            {
                starGraphics.FillRectangle(Star.brush, Star.point.X, Star.point.Y, 1, 1);
            }
            return starGraphics;
        }

        public virtual void Twinkle(Random random)
        {
            // Remove 4 stars and randomly place 4 new ones
        }
    }
}
