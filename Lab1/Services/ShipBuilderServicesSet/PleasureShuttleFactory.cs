using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.DeflectorAll;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineAll;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ShellAll;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ShipBuilderServicesSet;

public class PleasureShuttleFactory : ShipFactory
{
    public override DeflectorBase CreateDeflector(bool modification)
    {
        return new NullDeflector();
    }

    public override ShellBase CreateShell()
    {
        return new ShellTypeOne();
    }

    public override JumpingEngineBase CreateJumpingEngine()
    {
        return new NullJumpingEngine();
    }

    public override PulseEngineBase CreatePulseEngine()
    {
        return new PulseEngineTypeC();
    }

    public override AntiNitrineEmitter CreateAntiNitrineEmitter()
    {
        return new AntiNitrineEmitter(false);
    }
}