using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineAll;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ObstacleAll;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceAll;

public class NebulaeSpace : SpaceBase
{
    public NebulaeSpace(
        AntimatterObstacle? obstaclesSetAntimatter,
        int routeLenght)
        : base(obstaclesSetAntimatter, routeLenght)
    {
    }

    public override bool PassProcessing(ShipBase shipBase)
    {
        shipBase = shipBase ?? throw new ArgumentNullException(nameof(shipBase));
        if (shipBase.JumpEngine is NullJumpingEngine)
        {
            return false;
        }

        return true;
    }
}