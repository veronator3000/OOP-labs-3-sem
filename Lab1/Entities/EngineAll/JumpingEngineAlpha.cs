namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineAll;

public class JumpingEngineAlpha : JumpingEngineBase
{
    private const int RangeAbilityJumpingEngineAlpha = 64;
    private const int FuelConsumptionJumpingEngineAlpha = 9999;
    private const int FlowCoefficientJumpingEngineAlpha = 8;
    public JumpingEngineAlpha()
        : base(RangeAbilityJumpingEngineAlpha, FuelConsumptionJumpingEngineAlpha)
    {
    }

    public override double CalculateFuelConsumption(int routeLenght)
    {
        double tmp = (routeLenght / JumpingEngineDefaultSpeed) * FlowCoefficientJumpingEngineAlpha * routeLenght;
        return tmp;
    }
}