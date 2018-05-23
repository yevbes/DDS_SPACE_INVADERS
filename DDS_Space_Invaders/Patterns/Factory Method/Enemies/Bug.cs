using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Lab_3___Invaders.Factory
{
    class Bug : Invader
    {
        public Bug(ShipType invaderType, Point location, int score) : base(invaderType, location, score)
        {
        }
    }
}
