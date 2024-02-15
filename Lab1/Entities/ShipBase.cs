using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.DeflectorAll;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.EngineAll;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ObstacleAll;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ShellAll;
using Itmo.ObjectOrientedProgramming.Lab1.Services.ShipBuilderServicesSet;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class ShipBase
{
    public ShipBase(ShipFactory shipFactory, bool photonDeflectorModification = false)
    {
        if (shipFactory is null)
        {
            throw new ArgumentNullException(nameof(shipFactory));
        }

        Deflector = shipFactory.CreateDeflector(photonDeflectorModification);
        PulseEngine = shipFactory.CreatePulseEngine();
        Shell = shipFactory.CreateShell();
        Emitter = shipFactory.CreateAntiNitrineEmitter();
        IsShipAlive = true;
        PhotonDeflector = photonDeflectorModification;
        JumpEngine = shipFactory.CreateJumpingEngine();
    }

    public PulseEngineBase PulseEngine { get; private set; }

    public JumpingEngineBase JumpEngine { get; private set; }

    public ShellBase Shell { get; }
    public DeflectorBase Deflector { get; }
    public AntiNitrineEmitter Emitter { get; }

    public bool PhotonDeflector { get; private set; }

    public bool IsShipAlive { get; private set; }
    public bool IsCrewDead { get; private set; }

    public void TakeDamage(ObstacleBase? obstacle)
    {
        if (obstacle is null)
        {
            return;
        }

        if (obstacle is CosmoWhalesObstacle && Emitter.Instalattion)
        {
            return;
        }

        Deflector.TakeDamage(obstacle);
        if (obstacle is AntimatterObstacle && !Deflector.PhotonDeflector)
        {
            IsCrewDead = true;
            return;
        }

        Shell.TakeDamage(obstacle);
        if (Shell.CurrentHitPoints < 0)
        {
            IsShipAlive = false;
        }
        else
        {
            IsShipAlive = true;
        }
    }
}