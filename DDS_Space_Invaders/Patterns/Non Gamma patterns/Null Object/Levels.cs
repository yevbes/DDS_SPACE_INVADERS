using Invaders.Factory;
using System.Collections.Generic;
using System.Drawing;

namespace Invaders.Patterns.Non_Gamma_patterns.Null_Object
{
    public abstract class Levels
    {
        private const int FINAL_LEVEL = 6;
        protected List<Invader> invaders;
        protected const int invaderXSpacing = 60;
        protected const int invaderYSpacing = 60;
        private int wave = 0;
        protected int framesSkipped = 6;
        private Direction invaderDirection;

        protected Graphics graphics;
        protected Font messageFont;
        protected Rectangle formArea;
        public abstract void nextWave();

        protected Levels(List<Invader> invaders)
        {
            this.invaders = invaders;
        }

        public static int FINAL_LEVEL1 => FINAL_LEVEL;
        public int Wave { get => wave; set => wave = value; }
        public int FramesSkipped { get => framesSkipped; set => framesSkipped = value; }
        internal Direction InvaderDirection { get => invaderDirection; set => invaderDirection = value; }
    }
}
