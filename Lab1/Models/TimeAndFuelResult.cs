namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ResultAll;

public class TimeAndFuelResult
{
    public double TimeTravel { get; private set; }
    public double FuelTravel { get; private set; }

    public void TimeAndFuelCalculateResult(double timeTravelSp, double fuelTravelSp)
    {
        TimeTravel += timeTravelSp;
        FuelTravel += fuelTravelSp;
    }
}