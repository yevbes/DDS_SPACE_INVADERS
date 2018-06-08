using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invaders
{
    class EstrategiaDispara5 : IEstrategia
    {
        int IEstrategia.Exec()
        {
            int numShoots = 5;
            return numShoots;

        }
    }
}
