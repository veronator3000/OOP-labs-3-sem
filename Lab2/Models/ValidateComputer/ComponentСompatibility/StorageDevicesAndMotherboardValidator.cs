using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevicesComponent;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidateComputer.ComponentСompatibility;

public class StorageDevicesAndMotherboardValidator : IComputerValidator
{
    private const string Message = "incompatible components. unable to connect via SATA\n";

    public ValidateResult Validate(Computer computer)
    {
        computer = computer ?? throw new ArgumentNullException(nameof(computer));
        int count = 0;
        foreach (StorageDevicesBase storageDevices in computer.StorageDevicesComponent)
        {
            if (storageDevices.ConnectionType == "SATA")
            {
                count++;
                if (computer.MotherboardComponent.SataPortsMotherboard.SataPortsCount < count)
                {
                    return new ValidateResult.IncompatibleСomponentsResult(Message);
                }
            }
        }

        return new ValidateResult.SuccsesfulBuildResult(computer);
    }
}