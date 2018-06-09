using System.Drawing;

namespace Invaders.Patterns.Gamma_patterns.Facade
{
    struct ShapeStar
    {
        public Point point;
        public Brush brush;

        public ShapeStar(Point point, Brush brush)
        {
            this.point = point;
            this.brush = brush;
        }
    }
}
