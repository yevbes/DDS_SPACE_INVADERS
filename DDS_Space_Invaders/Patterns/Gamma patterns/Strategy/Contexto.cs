using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invaders.Patterns.Gamma_patterns.Strategy
{
    class Contexto
    {
        private IEstrategia strategy;

        public Contexto(IEstrategia strategy)
        {
            this.strategy = strategy;
        }

        public int ExecuteStrategy()
        {
            return strategy.Exec();
        }
    }
}