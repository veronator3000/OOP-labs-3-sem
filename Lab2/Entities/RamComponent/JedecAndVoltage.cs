using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RamComponent;

public class JedecAndVoltage
{
    public JedecAndVoltage(
        int voltage,
        IList<int> timing)
    {
        if (voltage < 0) throw new NegativeValueException();
        Voltage = voltage;
        Timing = timing;
    }

    public IList<int> Timing { get; }
    public int Voltage { get; }
}