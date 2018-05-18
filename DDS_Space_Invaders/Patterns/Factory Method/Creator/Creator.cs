using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Lab_3___Invaders.Factory
{
    abstract class Creator
    {
        public Product product { get; set; }
        abstract public Product FactoryMethod();
    }
}
