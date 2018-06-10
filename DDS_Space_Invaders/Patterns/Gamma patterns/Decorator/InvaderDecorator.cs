using Invaders;
using Invaders.Factory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Invaders.Patterns.Gamma_patterns.Decorator
{
    class InvaderDecorator : IDecor
    {
        protected IDecor decoratedInvader;

        public InvaderDecorator(IDecor invader)
        {
            this.decoratedInvader = invader;
        }

        public virtual Graphics Draw(Graphics graphics, int animationCell)
        {
            return this.decoratedInvader.Draw(graphics, animationCell);
        }
    }
}
