using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineAll;

public class PulseEngineTypeE : PulseEngineBase
{
    private const int SpeedPulseEngineTypeE = 6;
    private const int FuelConsumptionPulseEngineTypeE = 9;
    private const int FlowCoefficientPulseEngineTypeE = 10;
    public PulseEngineTypeE()
    : base(SpeedPulseEngineTypeE, FuelConsumptionPulseEngineTypeE)
    {
    }

    public override double CalculateFuelConsumption(int routeLenght)
    {
        double tmp = (routeLenght / Math.Exp(SpeedPulseEngineTypeE)) * FlowCoefficientPulseEngineTypeE;
        return tmp;
    }
}