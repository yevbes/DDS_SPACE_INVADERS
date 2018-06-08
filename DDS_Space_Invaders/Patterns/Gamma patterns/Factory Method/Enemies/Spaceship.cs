using System.Drawing;

namespace Invaders.Factory
{
    class Spaceship : Invader
    {
        public Spaceship(ShipType invaderType, Point location, int score) : base(invaderType, location, score)
        {
        }

        public override int AddAditionalScore(int score)
        {
            return score + 2;
        }
    }
}
