using System.Drawing;

namespace Invaders.Factory
{
    class Star : Invader
    {
        public Star(ShipType invaderType, Point location, int score) : base(invaderType, location, score)
        {
        }

        public override int AddAditionalScore(int score)
        {
            return score + 1;
        }
    }
}
