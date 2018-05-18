using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_3___Invaders.Resources
{
    class EstrategiaDispara4 : IEstrategia
    {
        int IEstrategia.Exec()
        {
            int numShoots = 4;
            return numShoots;
        }
        
    }
}
