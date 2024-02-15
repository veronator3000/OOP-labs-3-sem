using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolerComponent;

public class CoolerDimensions
{
    public CoolerDimensions(
        int widthCooler,
        int deepCooler,
        int lenghtCooler)
    {
        if (widthCooler < 0) throw new NegativeValueException();
        if (deepCooler < 0) throw new NegativeValueException();
        if (lenghtCooler < 0) throw new NegativeValueException();
        WidthCooler = widthCooler;
        DeepCooler = deepCooler;
        LenghtCooler = lenghtCooler;
    }

    public int DeepCooler { get; }
    public int WidthCooler { get; }
    public int LenghtCooler { get; }
}