using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ResultAll;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PassingRouteService;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.OptimalChoiceService;

public class SearchProfitableShip
{
    public ShipBase? ShipBest { get; private set; }

    public void ComparisonOfShips(ShipBase shipBaseFirst, ShipBase shipBaseSecond, RouteStorage routeStorage)
    {
        shipBaseFirst = shipBaseFirst ?? throw new ArgumentNullException(nameof(shipBaseFirst));
        shipBaseSecond = shipBaseSecond ?? throw new ArgumentNullException(nameof(shipBaseSecond));
        routeStorage = routeStorage ?? throw new ArgumentNullException(nameof(routeStorage));

        var timeAndFuel1 = new TimeAndFuelResult();
        var timeAndFuel2 = new TimeAndFuelResult();
        JourneyResult result1 = routeStorage.MakeResult(shipBaseFirst, timeAndFuel1);
        JourneyResult result2 = routeStorage.MakeResult(shipBaseSecond, timeAndFuel2);

        if (result1 is JourneyResult.IsShipDead or JourneyResult.IsShipLost or JourneyResult.IsCrewDead && result2 is not JourneyResult.IsShipDead)
        {
            ShipBest = shipBaseSecond;
        }
        else if (result1 is not JourneyResult.IsShipDead && result2 is JourneyResult.IsShipDead or JourneyResult.IsShipLost or JourneyResult.IsCrewDead)
        {
            ShipBest = shipBaseFirst;
        }
        else if (result1 is not JourneyResult.IsShipDead && result2 is not JourneyResult.IsShipDead)
        {
            ShipBest = timeAndFuel1.FuelTravel > timeAndFuel2.FuelTravel ? shipBaseSecond : shipBaseFirst;
        }
        else
        {
            return;
        }
    }
}