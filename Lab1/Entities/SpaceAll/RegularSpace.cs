using Itmo.ObjectOrientedProgramming.Lab1.Entities.ObstacleAll;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceAll;

public class RegularSpace : SpaceBase
{
    public RegularSpace(
        LargeAsteroid? obstaclesLargeAsteroid,
        SmallAsteroid? smallAsteroid,
        int routeLenght)
        : base(obstaclesLargeAsteroid, routeLenght)
    {
        Asteroid = smallAsteroid;
    }

    public ObstacleBase? Asteroid { get; }
    public override bool PassProcessing(ShipBase shipBase)
    {
        return true;
    }
}