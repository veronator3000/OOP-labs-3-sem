using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WifiComponent;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidateComputer.ComponentСompatibility;

public class PowerUnitAndAllValidator : IComputerValidator
{
    private const string Message = "no guarantee. non-compliance with the recommended power unit\n";
    public ValidateResult Validate(Computer computer)
    {
        computer = computer ?? throw new ArgumentNullException(nameof(computer));
        int voltage = computer.RamComponent.Sum(ram => ram.PowerConsumption);

        voltage += computer.CpuComponent.PowerConsumption;
        if (computer.GpuComponent is not null)
        {
            voltage += computer.GpuComponent.GraphicsCardPowerConsumption;
        }

        voltage += computer.StorageDevicesComponent.Sum(storageDevices => storageDevices.PowerConsumption);
        if (computer.WifiComponent is WifiAdapter wifiAdapter)
        {
            voltage += wifiAdapter.PowerConsumption;
        }

        if (voltage > computer.PowerUnitComponent.PeakPowerLoad)
        {
            return new ValidateResult.WarningWithoutGuaranteeResult(computer, Message);
        }

        return new ValidateResult.SuccsesfulBuildResult(computer);
    }
}