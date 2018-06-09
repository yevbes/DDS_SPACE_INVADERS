using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Invaders.Patterns.Gamma_patterns.Facade
{
    interface IShape
    {
        Graphics Draw(Graphics graphics);
        void Twinkle(Random random);
    }
}
