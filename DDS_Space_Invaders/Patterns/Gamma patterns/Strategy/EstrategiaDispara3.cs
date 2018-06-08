namespace Invaders
{
    class EstrategiaDispara3 : IEstrategia
    {
        int IEstrategia.Exec()
        {
            int numShoots = 3;
            return numShoots;
        }
        
    }
}
