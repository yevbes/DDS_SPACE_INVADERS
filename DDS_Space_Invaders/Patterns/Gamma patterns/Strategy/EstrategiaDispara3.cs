namespace Invaders
{
    class EstrategiaDispara3 : IEstrategia
    {
        int IEstrategia.EjecutarEstrategia()
        {
            int numShoots = 3;
            return numShoots;
        }
        
    }
}
