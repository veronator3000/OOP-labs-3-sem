using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CaseComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolerComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GraphicsCardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevicesComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WifiComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ValidateComputer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerBuilders;

public class ComputerBuilder : IComputerBuilder
{
    private Motherboard? _motherboard;
    private Cpu? _cpu;
    private IReadOnlyCollection<Ram>? _ramList;
    private IReadOnlyCollection<StorageDevicesBase>? _storageDevicesList;
    private CoolingSystem? _coolingSystem;
    private CaseType? _caseType;
    private GraphicsCard? _graphicsCard;
    private WifiBase? _wifi;
    private PowerUnit? _powerUnit;
    private string? _name;
    public IList<ValidateResult> ValidateResults { get; private set; } = new List<ValidateResult>();

    private ValidateAll ValidateAll { get; } = new ValidateAll();

    public IComputerBuilder SetMotherboard(Motherboard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public IComputerBuilder SetCpu(Cpu cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IComputerBuilder SetRam(IReadOnlyCollection<Ram> ram)
    {
        _ramList = ram;
        return this;
    }

    public IComputerBuilder SetStorageDevice(IReadOnlyCollection<StorageDevicesBase> storageDevice)
    {
        _storageDevicesList = storageDevice;
        return this;
    }

    public IComputerBuilder SetCoolingSystem(CoolingSystem coolingSystem)
    {
        _coolingSystem = coolingSystem;
        return this;
    }

    public IComputerBuilder SetCaseType(CaseType caseType)
    {
        _caseType = caseType;
        return this;
    }

    public IComputerBuilder SetGraphicsCard(GraphicsCard graphicsCard)
    {
        _graphicsCard = graphicsCard;
        return this;
    }

    public IComputerBuilder SetWifi(WifiBase wifi)
    {
        _wifi = wifi;
        return this;
    }

    public IComputerBuilder SetPowerUnit(PowerUnit powerUnit)
    {
        _powerUnit = powerUnit;
        return this;
    }

    public IComputerBuilder SetComputerName(string nameComputer)
    {
        _name = nameComputer;
        return this;
    }

    public Computer? Build()
    {
        var computerTempForValidation = new Computer(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _motherboard ?? throw new ArgumentNullException(nameof(_motherboard)),
            _cpu ?? throw new ArgumentNullException(nameof(_cpu)),
            _ramList ?? throw new ArgumentNullException(nameof(_ramList)),
            _coolingSystem ?? throw new ArgumentNullException(nameof(_coolingSystem)),
            _caseType ?? throw new ArgumentNullException(nameof(_caseType)),
            _storageDevicesList ?? throw new ArgumentNullException(nameof(_storageDevicesList)),
            _powerUnit ?? throw new ArgumentNullException(nameof(_powerUnit)),
            _graphicsCard,
            _wifi);
        ValidateResults = ValidateAll.Validate(computerTempForValidation);
        if (ValidateResults[0] is ValidateResult.IncompatibleСomponentsResult)
        {
            return null;
        }

        return computerTempForValidation;
    }
}