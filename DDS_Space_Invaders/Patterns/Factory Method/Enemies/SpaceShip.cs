using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Lab_3___Invaders.Factory
{
    class Spaceship : Invader
    {
        public Spaceship(ShipType invaderType, Point location, int score) : base(invaderType, location, score)
        {
        }
    }
}
