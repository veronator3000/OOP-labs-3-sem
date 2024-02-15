namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ObstacleAll;

public class SmallAsteroid : ObstacleBase
{
    private const int SmallAsteroidDamage = 99;
    public SmallAsteroid(int count)
        : base(count * SmallAsteroidDamage)
    {
    }
}