namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ObstacleAll;

public class LargeAsteroid : ObstacleBase
{
    private const int LargeAsteroidDamage = 200;
    public LargeAsteroid(int count)
        : base(count * LargeAsteroidDamage)
    {
    }
}