using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.DeflectorAll;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineAll;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ShellAll;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ShipBuilderServicesSet;

public abstract class ShipFactory
{
    public abstract DeflectorBase CreateDeflector(bool modification);
    public abstract ShellBase CreateShell();
    public abstract AntiNitrineEmitter CreateAntiNitrineEmitter();

    public abstract JumpingEngineBase CreateJumpingEngine();
    public abstract PulseEngineBase CreatePulseEngine();
}