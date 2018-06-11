namespace Invaders
{
    class EstrategiaDispara4 : IEstrategia
    {
        int IEstrategia.EjecutarEstrategia()
        {
            int numShoots = 4;
            return numShoots;
        }
        
    }
}
