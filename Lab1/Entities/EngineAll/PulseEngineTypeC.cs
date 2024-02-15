namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineAll;

public class PulseEngineTypeC : PulseEngineBase
{
    private const int SpeedPulseEngineTypeC = 666;
    private const int FuelConsumptionPulseEngineTypeC = 99;
    private const int FlowCoefficientPulseEngineTypeC = 1;
    public PulseEngineTypeC()
        : base(SpeedPulseEngineTypeC, FuelConsumptionPulseEngineTypeC)
    {
    }

    public override double CalculateFuelConsumption(int routeLenght)
    {
        double tmp = (routeLenght / SpeedPulseEngineTypeC) * FlowCoefficientPulseEngineTypeC;
        return tmp;
    }
}