using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_3___Invaders.Factory
{
    class BugFourEnemy : Enemy
    {
        public BugFourEnemy(string n) : base(n)
        { }

        public override Invader Create()
        {
            return new BugFour();
        }
    }
}
