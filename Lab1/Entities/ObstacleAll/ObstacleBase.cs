using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ObstacleAll;

public abstract class ObstacleBase
{
    protected ObstacleBase(int maxDamageAbility)
    {
        if (maxDamageAbility < 0)
        {
            throw new NegativeValueException(nameof(maxDamageAbility));
        }

        DamageAbility = maxDamageAbility;
    }

    public bool IsAlive => DamageAbility > 0;

    public int DamageAbility { get; protected set; }
    public void TakeDamage(int actual)
    {
        if (actual < 0) throw new ArgumentException("actual must be positive", nameof(actual));
        DamageAbility -= actual;
    }
}