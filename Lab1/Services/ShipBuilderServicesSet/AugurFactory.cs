using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.DeflectorAll;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineAll;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ShellAll;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ShipBuilderServicesSet;

public class AugurFactory : ShipFactory
{
    public override DeflectorBase CreateDeflector(bool modification)
    {
        return new DeflectorTypeThree(modification);
    }

    public override ShellBase CreateShell()
    {
        return new ShellTypeThree();
    }

    public override JumpingEngineBase CreateJumpingEngine()
    {
        return new JumpingEngineAlpha();
    }

    public override PulseEngineBase CreatePulseEngine()
    {
        return new PulseEngineTypeE();
    }

    public override AntiNitrineEmitter CreateAntiNitrineEmitter()
    {
        return new AntiNitrineEmitter(false);
    }
}