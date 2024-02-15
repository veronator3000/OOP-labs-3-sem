using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponent;

public class DocpProfile : ComponentBase
{
    public DocpProfile(
        string nameDocp,
        int docpFrequency,
        int docpTiming,
        int docpVoltage)
    : base(nameDocp)
    {
        if (docpFrequency < 0) throw new NegativeValueException();
        if (docpTiming < 0) throw new NegativeValueException();
        if (docpVoltage < 0) throw new NegativeValueException();
        DocpFrequency = docpFrequency;
        DocpTiming = docpTiming;
        DocpVoltage = docpVoltage;
    }

    public int DocpFrequency { get; }
    public int DocpTiming { get; }
    public int DocpVoltage { get; }
}