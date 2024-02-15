namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.DeflectorAll;

public class DeflectorTypeOne : DeflectorBase
{
    private const int MaxHitPointsDeflector1 = 180;
    public DeflectorTypeOne(bool photonDeflectorModification)
        : base(MaxHitPointsDeflector1, photonDeflectorModification)
    {
    }
}