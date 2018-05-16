using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_3___Invaders.Factory
{
    class BugThreeEnemy : Enemy
    {
        public BugThreeEnemy(string n) : base(n)
        { }

        public override Invader Create()
        {
            return new BugThree();
        }
    }
}
