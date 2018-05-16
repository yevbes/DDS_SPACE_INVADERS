using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_3___Invaders.Factory
{
    abstract class Enemy
    {
        public string Img { get; set;}
        public Enemy(string img)
        {
            Img = img;
        }

        abstract public Invader Create();
    }
}
