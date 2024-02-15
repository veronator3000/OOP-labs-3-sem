namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineAll;

public class JumpingEngineOmega : JumpingEngineBase
{
    private const int RangeAbilityJumpingEngineOmega = 666;
    private const int FuelConsumptionJumpingEngineOmega = 9999;
    public JumpingEngineOmega()
        : base(RangeAbilityJumpingEngineOmega, FuelConsumptionJumpingEngineOmega)
    {
    }

    public override double CalculateFuelConsumption(int routeLenght)
    {
        double tmp = (routeLenght / JumpingEngineDefaultSpeed) * routeLenght;
        return tmp;
    }
}