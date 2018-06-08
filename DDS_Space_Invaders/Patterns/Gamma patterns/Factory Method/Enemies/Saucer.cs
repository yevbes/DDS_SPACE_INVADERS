using System.Drawing;

namespace Invaders.Factory
{
    class Saucer : Invader
    {
        public Saucer(ShipType invaderType, Point location, int score) : base(invaderType, location, score)
        {
        }

        public override int AddAditionalScore(int score)
        {
            return score + 3;
        }
    }
}
