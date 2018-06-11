namespace Invaders
{
    class EstrategiaDispara5 : IEstrategia
    {
        int IEstrategia.EjecutarEstrategia()
        {
            int numShoots = 5;
            return numShoots;

        }
    }
}
