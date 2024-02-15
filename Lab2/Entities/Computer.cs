using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CaseComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolerComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GraphicsCardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevicesComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WifiComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Computer : ComponentBase
{
    public Computer(
        string nameComputer,
        Motherboard motherboardComponent,
        Cpu cpuComponent,
        IReadOnlyCollection<Ram> ramComponent,
        CoolingSystem coolingSystemComponent,
        CaseType caseComponent,
        IReadOnlyCollection<StorageDevicesBase> storageDevicesComponent,
        PowerUnit powerUnitComponent,
        GraphicsCard? gpuComponent,
        WifiBase? wifiComponent)
    : base(nameComputer)
    {
        MotherboardComponent = motherboardComponent;
        CpuComponent = cpuComponent;
        RamComponent = ramComponent;
        CoolingSystemComponent = coolingSystemComponent;
        CaseComponent = caseComponent;
        StorageDevicesComponent = storageDevicesComponent;
        PowerUnitComponent = powerUnitComponent;
        GpuComponent = gpuComponent;
        WifiComponent = wifiComponent;
    }

    public Motherboard MotherboardComponent { get; }
    public Cpu CpuComponent { get; }
    public IReadOnlyCollection<Ram> RamComponent { get; }
    public IReadOnlyCollection<StorageDevicesBase> StorageDevicesComponent { get; }
    public CoolingSystem CoolingSystemComponent { get; }
    public CaseType CaseComponent { get; }
    public GraphicsCard? GpuComponent { get; }
    public WifiBase? WifiComponent { get; }
    public PowerUnit PowerUnitComponent { get; }

    public IComputerBuilder Debuild(IComputerBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        builder
            .SetMotherboard(MotherboardComponent)
            .SetCpu(CpuComponent)
            .SetRam(RamComponent)
            .SetCoolingSystem(CoolingSystemComponent)
            .SetStorageDevice(StorageDevicesComponent)
            .SetPowerUnit(PowerUnitComponent);
        if (GpuComponent is not null)
        {
            builder.SetGraphicsCard(GpuComponent);
        }

        if (WifiComponent is not null)
        {
            builder.SetWifi(WifiComponent);
        }

        builder.SetCaseType(CaseComponent);
        return builder;
    }
}