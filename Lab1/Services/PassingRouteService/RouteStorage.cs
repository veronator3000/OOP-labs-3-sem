using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ResultAll;
namespace Itmo.ObjectOrientedProgramming.Lab1.Services.PassingRouteService;

public class RouteStorage
{
    public RouteStorage(IReadOnlyCollection<PartlyRouteResult> route)
    {
        if (route == null || route.Count == 0)
        {
            throw new EmptyRoadException(nameof(route));
        }

        Route = route;
    }

    public IReadOnlyCollection<PartlyRouteResult> Route { get; }

    public JourneyResult MakeResult(ShipBase shipBase, TimeAndFuelResult timeAndFuelResult)
    {
        foreach (PartlyRouteResult partlyRouteResult in Route)
        {
            if (partlyRouteResult.SpaceCheck(shipBase, timeAndFuelResult) is not JourneyResult.IsSuccessfulJourney)
            {
                return partlyRouteResult.SpaceCheck(shipBase, timeAndFuelResult);
            }
        }

        return new JourneyResult.IsSuccessfulJourney();
    }
}