using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponent;

public class Chipset : ComponentBase
{
    public Chipset(
        string chipsetName,
        double availableMemoryFrequencies,
        XmpProfile? xmpProfileType,
        DocpProfile? docpProfileType)
    : base(chipsetName)
    {
        if (availableMemoryFrequencies < 0) throw new NegativeValueException();
        AvailableMemoryFrequencies = availableMemoryFrequencies;
        XmpProfileType = xmpProfileType;
        DocpProfileType = docpProfileType;
    }

    public double AvailableMemoryFrequencies { get; }
    public XmpProfile? XmpProfileType { get; }
    public DocpProfile? DocpProfileType { get; }
}