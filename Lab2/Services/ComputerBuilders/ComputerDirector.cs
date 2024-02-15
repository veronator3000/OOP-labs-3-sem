using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CaseComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolerComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GraphicsCardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Storage;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevicesComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WifiComponent;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerBuilders;

public class ComputerDirector
{
    private readonly IComputerBuilder _builder;
    private readonly AllRepository _allRepository;

    public ComputerDirector(
        IComputerBuilder builder,
        AllRepository repository)
    {
        _builder = builder;
        _allRepository = repository;
    }

    public Computer? Direct(Specification specification)
    {
        specification = specification ?? throw new ArgumentNullException(nameof(specification));
        Cpu cpu = _allRepository.CpuComponent.GetComponent(specification.CpuName);
        Motherboard motherboard = _allRepository.MotherboardComponent.GetComponent(specification.MotherboardName);
        IReadOnlyCollection<Ram> ramList = specification.RamName
            .Select(name => _allRepository.RamRepository.GetComponent(name))
            .ToList();
        CoolingSystem coolingSystem =
            _allRepository.CoolingSystemComponent.GetComponent(specification.CoolingSystemName);
        CaseType caseType = _allRepository.CaseComponent.GetComponent(specification.CaseName);
        PowerUnit powerUnit = _allRepository.PowerUnitRepository.GetComponent(specification.PowerUnitName);
        IReadOnlyCollection<StorageDevicesBase> storageDevices = specification.StorageDevicesName
            .Select(name => _allRepository.StorageDevicesRepository.GetComponent(name))
            .ToList();

        _builder
            .SetMotherboard(motherboard)
            .SetCpu(cpu)
            .SetRam(ramList)
            .SetCoolingSystem(coolingSystem)
            .SetStorageDevice(storageDevices)
            .SetPowerUnit(powerUnit);
        if (!string.IsNullOrEmpty(specification.GraphicsCardName))
        {
            GraphicsCard graphicsCard = _allRepository.GraphicsCardRepository.GetComponent(specification.GraphicsCardName);
            _builder.SetGraphicsCard(graphicsCard);
        }

        if (!string.IsNullOrEmpty(specification.WifiName))
        {
            WifiBase wifiBase = _allRepository.WifiComponentRepository.GetComponent(specification.WifiName);
            _builder.SetWifi(wifiBase);
        }

        if (!string.IsNullOrEmpty(specification.ComputerName))
        {
            _builder.SetComputerName(specification.ComputerName);
        }

        _builder.SetCaseType(caseType);
        return _builder.Build();
    }
}