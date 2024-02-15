using Itmo.ObjectOrientedProgramming.Lab1.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineAll;

public abstract class PulseEngineBase
{
    protected PulseEngineBase(int speed, int fuelConsumption)
    {
        if (speed < 0)
        {
            throw new NegativeValueException(nameof(speed));
        }

        if (fuelConsumption < 0)
        {
            throw new NegativeValueException(nameof(fuelConsumption));
        }

        Speed = speed;
        FuelConsumption = fuelConsumption;
    }

    public int Speed { get; }
    public int FuelConsumption { get; protected set; }
    public double CalculateTime(int routeLenght)
    {
        double time = routeLenght / Speed;
        return time;
    }

    public abstract double CalculateFuelConsumption(int routeLenght);
}