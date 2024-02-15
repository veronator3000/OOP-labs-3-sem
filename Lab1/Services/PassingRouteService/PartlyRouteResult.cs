using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceAll;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ResultAll;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.PassingRouteService;

public class PartlyRouteResult
{
    public PartlyRouteResult(SpaceBase spaceBasePart)
    {
        SpaceBasePart = spaceBasePart ?? throw new ArgumentNullException(nameof(spaceBasePart));
        SpaceBasePart = spaceBasePart;
    }

    public SpaceBase SpaceBasePart { get; }

    public JourneyResult SpaceCheck(ShipBase shipBase, TimeAndFuelResult timeAndFuelResult)
    {
        timeAndFuelResult = timeAndFuelResult ?? throw new ArgumentNullException(nameof(timeAndFuelResult));
        shipBase = shipBase ?? throw new ArgumentNullException(nameof(shipBase));
        if (!SpaceBasePart.PassProcessing(shipBase))
        {
            return new JourneyResult.IsShipDead();
        }

        if (SpaceBasePart is NebulaeSpace)
        {
            if (!shipBase.JumpEngine.CanJump(SpaceBasePart.RouteLenght))
            {
                return new JourneyResult.IsShipLost();
            }

            timeAndFuelResult.TimeAndFuelCalculateResult(
                shipBase.JumpEngine.CalculateTime(SpaceBasePart.RouteLenght),
                shipBase.JumpEngine.CalculateFuelConsumption(SpaceBasePart.RouteLenght));
        }

        shipBase.TakeDamage(SpaceBasePart.ObstaclesSetBase);
        if (shipBase.IsCrewDead)
        {
            return new JourneyResult.IsCrewDead();
        }

        if (!shipBase.IsShipAlive)
        {
            return new JourneyResult.IsShipDead();
        }

        timeAndFuelResult.TimeAndFuelCalculateResult(
            shipBase.PulseEngine.CalculateTime(SpaceBasePart.RouteLenght),
            shipBase.PulseEngine.CalculateFuelConsumption(SpaceBasePart.RouteLenght));
        return new JourneyResult.IsSuccessfulJourney();
    }
}