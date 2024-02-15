namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineAll;

public class NullJumpingEngine : JumpingEngineBase
{
    public NullJumpingEngine()
        : base(0, 0)
    {
    }

    public override double CalculateFuelConsumption(int routeLenght)
    {
        return 0;
    }
}