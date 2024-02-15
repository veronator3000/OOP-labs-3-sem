using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponent;

public class XmpProfile
{
    public XmpProfile(
        int xmpFrequency,
        int xmpTiming,
        int xmpVoltage)
    {
        if (xmpFrequency < 0) throw new NegativeValueException();
        if (xmpTiming < 0) throw new NegativeValueException();
        if (xmpVoltage < 0) throw new NegativeValueException();
        XmpFrequency = xmpFrequency;
        XmpTiming = xmpTiming;
        XmpVoltage = xmpVoltage;
    }

    public int XmpFrequency { get; }
    public int XmpTiming { get; }
    public int XmpVoltage { get; }
}