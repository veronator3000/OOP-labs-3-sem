namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralAttributes;

public class SataPorts : ComponentBase
{
    public SataPorts(string sataPortsName)
    : base(sataPortsName)
    {
    }

    public int SataPortsCount { get; }
}