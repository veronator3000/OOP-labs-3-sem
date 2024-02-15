namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineAll;

public class JumpingEngineGamma : JumpingEngineBase
{
    private const int RangeAbilityJumpingEngineGamma = 999;
    private const int FuelConsumptionJumpingEngineGamma = 9999;
    public JumpingEngineGamma()
        : base(RangeAbilityJumpingEngineGamma, FuelConsumptionJumpingEngineGamma)
    {
    }

    public override double CalculateFuelConsumption(int routeLenght)
    {
        double tmp = (routeLenght / JumpingEngineDefaultSpeed) * routeLenght;
        return tmp;
    }
}