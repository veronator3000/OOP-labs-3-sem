using Itmo.ObjectOrientedProgramming.Lab1.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ObstacleAll;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceAll;

public abstract class SpaceBase
{
    protected SpaceBase(
        ObstacleBase? obstaclesSetBase, int routeLenght)
    {
        if (routeLenght < 0)
        {
            throw new NegativeValueException(nameof(routeLenght));
        }

        ObstaclesSetBase = obstaclesSetBase;
        RouteLenght = routeLenght;
    }

    public ObstacleBase? ObstaclesSetBase { get; }
    public int RouteLenght { get; private set; }

    public abstract bool PassProcessing(ShipBase shipBase);
}
