﻿using System.Collections.Generic;
using System.Drawing;
using Invaders.Factory;

namespace Invaders.Patterns.Non_Gamma_patterns.Null_Object
{
    class NullLevel : Levels
    {
        public NullLevel(List<Invader> invaders, Graphics graphics, Font messageFont, Rectangle formArea) : base(invaders)
        {
            this.graphics = graphics;
            this.messageFont = messageFont;
            this.formArea = formArea;
        }

        public override void nextWave()
        {
            graphics.DrawString("GAME OVER", messageFont, Brushes.Red,
                    (formArea.Width / 4), formArea.Height / 3);
        }
    }
}
