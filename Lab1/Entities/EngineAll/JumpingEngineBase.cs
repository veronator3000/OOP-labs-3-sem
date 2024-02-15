using Itmo.ObjectOrientedProgramming.Lab1.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineAll;

public abstract class JumpingEngineBase
{
    protected JumpingEngineBase(int rangeAbility, int fuelConsumption)
    {
        if (rangeAbility < 0)
        {
            throw new NegativeValueException(nameof(rangeAbility));
        }

        if (fuelConsumption < 0)
        {
            throw new NegativeValueException(nameof(fuelConsumption));
        }

        FuelConsumption = fuelConsumption;
        RangeAbility = rangeAbility;
    }

    public int JumpingEngineDefaultSpeed { get; } = 5000;
    public int RangeAbility { get; }
    public int FuelConsumption { get; protected set; }

    public abstract double CalculateFuelConsumption(int routeLenght);

    public double CalculateTime(int routeLenght)
    {
        double tmp = routeLenght / JumpingEngineDefaultSpeed;
        return tmp;
    }

    public bool CanJump(int routeLenght)
    {
        if (RangeAbility < routeLenght)
        {
            return false;
        }

        return true;
    }
}