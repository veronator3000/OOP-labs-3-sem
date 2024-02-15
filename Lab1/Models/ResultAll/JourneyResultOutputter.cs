using System;
namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ResultAll;

public sealed record JourneyResultOutputter
{
    public string JourneyResultStatus(JourneyResult result, TimeAndFuelResult timeAndFuelResult)
    {
        timeAndFuelResult = timeAndFuelResult ?? throw new ArgumentNullException(nameof(timeAndFuelResult));
        if (result is JourneyResult.IsShipDead or JourneyResult.IsCrewDead or JourneyResult.IsShipLost)
        {
            return
                $"unsuccessful flight";
        }

        if (result is JourneyResult.IsSuccessfulJourney)
        {
            return
                $"successful flight. fuel: {timeAndFuelResult.FuelTravel}, time: {timeAndFuelResult.TimeTravel}";
        }

        return $"noway";
    }
}