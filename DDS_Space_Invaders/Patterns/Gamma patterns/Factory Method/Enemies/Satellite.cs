using System.Drawing;

namespace Invaders.Factory
{
    class Satellite : Invader
    {
        public Satellite(ShipType invaderType, Point location, int score) : base(invaderType, location, score)
        {
        }

        public override int AddAditionalScore(int score)
        {
            return score + 4;
        }

    }
}
