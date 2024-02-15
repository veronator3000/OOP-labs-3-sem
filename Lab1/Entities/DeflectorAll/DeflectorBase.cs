using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ObstacleAll;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.DeflectorAll;
public abstract class DeflectorBase
{
    protected DeflectorBase(int maxHitPoints, bool photonDeflectorModification = false)
    {
        if (maxHitPoints < 0)
        {
            throw new NegativeValueException(nameof(maxHitPoints));
        }

        PhotonDeflector = photonDeflectorModification;
        CurrentHitPoints = maxHitPoints;
        if (PhotonDeflector)
        {
            PhotonCharge = 3;
        }
        else
        {
            PhotonCharge = 0;
        }
    }

    public bool PhotonDeflector { get; private set; }
    private int PhotonCharge { get; set; }

    private int CurrentHitPoints { get; set; }

    public virtual void TakeDamage(ObstacleBase obstacle)
    {
        obstacle = obstacle ?? throw new ArgumentNullException(nameof(obstacle));
        if (obstacle is AntimatterObstacle && PhotonDeflector)
        {
            PhotonCharge--;
            if (PhotonCharge <= 0)
            {
                PhotonDeflector = false;
            }
        }

        int actual = CurrentHitPoints > obstacle.DamageAbility ? obstacle.DamageAbility : CurrentHitPoints;
        CurrentHitPoints -= actual;
        obstacle.TakeDamage(actual);
    }
}