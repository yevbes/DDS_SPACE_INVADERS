using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Invaders.Patterns.Gamma_patterns.Facade
{
    class StarMaker
    {
        private Star whiteStar;
        private Star yellowStar;
        private Star blueStar;

        public StarMaker(Random random, Rectangle formArea)
        {
            whiteStar = new WhiteStar(random, formArea);
            yellowStar = new YellowStar(random, formArea);
            blueStar = new BlueStar(random, formArea);
        }

        public void DrawWhiteStar(Graphics graphics)
        {
            whiteStar.Draw(graphics);
        }
        public void DrawYellowStar(Graphics graphics)
        {
            yellowStar.Draw(graphics);
        }
        public void DrawBlueStar(Graphics graphics)
        {
            blueStar.Draw(graphics);
        }

        public void Twinkle(Random random)
        {
            yellowStar.Twinkle(random);
            whiteStar.Twinkle(random);
            blueStar.Twinkle(random);
        }
    }
}
