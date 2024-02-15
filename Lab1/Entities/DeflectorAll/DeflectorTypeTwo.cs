namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.DeflectorAll;

public class DeflectorTypeTwo : DeflectorBase
{
    private const int MaxHitPointsDeflector2 = 540;
    public DeflectorTypeTwo(bool photonDeflectorModification)
        : base(MaxHitPointsDeflector2, photonDeflectorModification)
    {
    }
}