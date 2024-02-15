using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CaseComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolerComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GraphicsCardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevicesComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WifiComponent;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerBuilders;

public interface IComputerBuilder
{
    IComputerBuilder SetMotherboard(Motherboard motherboard);
    IComputerBuilder SetCpu(Cpu cpu);
    IComputerBuilder SetRam(IReadOnlyCollection<Ram> ram);
    IComputerBuilder SetStorageDevice(IReadOnlyCollection<StorageDevicesBase> storageDevice);
    IComputerBuilder SetCoolingSystem(CoolingSystem coolingSystem);
    IComputerBuilder SetCaseType(CaseType caseType);
    IComputerBuilder SetGraphicsCard(GraphicsCard graphicsCard);
    IComputerBuilder SetWifi(WifiBase wifi);
    IComputerBuilder SetPowerUnit(PowerUnit powerUnit);
    IComputerBuilder SetComputerName(string nameComputer);
    Computer? Build();
}