using System.Drawing;

namespace Invaders.Factory
{
    public class Bug : Invader
    {
        public Bug(ShipType invaderType, Point location, int score) : base(invaderType, location, score)
        {
        }

        public override int AddAditionalScore(int score)
        {
            return score + 5;
        }
    }
}
