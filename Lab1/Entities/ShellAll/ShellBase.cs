using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ObstacleAll;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ShellAll;

public abstract class ShellBase
{
    protected ShellBase(int maxHitPoints)
    {
        if (maxHitPoints <= 0)
        {
            throw new NegativeValueException(nameof(maxHitPoints));
        }

        MaxHitPoints = maxHitPoints;
        CurrentHitPoints = maxHitPoints;
    }

    public int MaxHitPoints { get; }

    public bool IsAlive => CurrentHitPoints > 0;

    public int CurrentHitPoints { get; private set; }

    public void TakeDamage(ObstacleBase obstacle)
    {
        obstacle = obstacle ?? throw new ArgumentNullException(nameof(obstacle));
        if (obstacle.DamageAbility >= CurrentHitPoints)
        {
            CurrentHitPoints = 0;
        }
        else
        {
            CurrentHitPoints -= obstacle.DamageAbility;
        }
    }
}
