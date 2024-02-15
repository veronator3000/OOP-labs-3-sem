using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.DeflectorAll;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineAll;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ShellAll;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ShipBuilderServicesSet;

public class MeridianFactory : ShipFactory
{
    // public MeridianBuilder(bool deflectorModification = false)
    // {
    //     DeflectorModification = deflectorModification;
    // }
    //
    // public bool DeflectorModification { get; private set; }
    public override DeflectorBase CreateDeflector(bool modification)
    {
        return new DeflectorTypeTwo(modification);
    }

    public override ShellBase CreateShell()
    {
        return new ShellTypeTwo();
    }

    public override JumpingEngineBase CreateJumpingEngine()
    {
        return new JumpingEngineGamma();
    }

    public override PulseEngineBase CreatePulseEngine()
    {
        return new PulseEngineTypeE();
    }

    public override AntiNitrineEmitter CreateAntiNitrineEmitter()
    {
        return new AntiNitrineEmitter(true);
    }
}
