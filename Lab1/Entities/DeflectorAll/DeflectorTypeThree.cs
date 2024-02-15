namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.DeflectorAll;

public class DeflectorTypeThree : DeflectorBase
{
    private const int MaxHitPointsDeflector3 = 10000;
    public DeflectorTypeThree(bool photonDeflectorModification)
        : base(MaxHitPointsDeflector3, photonDeflectorModification)
    {
    }
}