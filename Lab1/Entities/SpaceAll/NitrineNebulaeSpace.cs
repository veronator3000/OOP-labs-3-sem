using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineAll;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ObstacleAll;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceAll;

public class NitrineNebulaeSpace : SpaceBase
{
    public NitrineNebulaeSpace(
        CosmoWhalesObstacle? obstacleCosmoWhales,
        int routeLenght)
        : base(obstacleCosmoWhales, routeLenght)
    {
    }

    public override bool PassProcessing(ShipBase shipBase)
    {
        shipBase = shipBase ?? throw new ArgumentNullException(nameof(shipBase));
        if (shipBase.PulseEngine is not PulseEngineTypeE)
        {
            return false;
        }

        return true;
    }
}