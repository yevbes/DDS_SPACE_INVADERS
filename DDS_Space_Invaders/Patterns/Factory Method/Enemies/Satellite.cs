using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Lab_3___Invaders.Factory
{
    class Satellite : Invader
    {
        public Satellite(ShipType invaderType, Point location, int score) : base(invaderType, location, score)
        {
        }
    }
}
