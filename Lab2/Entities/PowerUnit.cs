using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PowerUnit : ComponentBase
{
    public PowerUnit(
        string namePowerUnit,
        int peakPowerLoad)
    : base(namePowerUnit)
    {
        if (peakPowerLoad < 0) throw new NegativeValueException();
        PeakPowerLoad = peakPowerLoad;
    }

    public int PeakPowerLoad { get; }
}