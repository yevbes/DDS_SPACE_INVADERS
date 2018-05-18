using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Lab_3___Invaders.Factory
{
    class ConcreteCreatorOne : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductOne();
        }
    }
}
