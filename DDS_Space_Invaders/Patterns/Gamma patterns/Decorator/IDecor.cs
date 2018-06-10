using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Invaders.Patterns.Gamma_patterns.Decorator
{
    interface IDecor
    {
        Graphics Draw(Graphics graphics, int animationCell);
    }
}
