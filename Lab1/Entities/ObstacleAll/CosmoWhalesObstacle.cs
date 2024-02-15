namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ObstacleAll;

public class CosmoWhalesObstacle : ObstacleBase
{
    private const int CosmoWhalesDamage = 10000;
    public CosmoWhalesObstacle(int population)
        : base(CosmoWhalesDamage * population)
    {
    }
}