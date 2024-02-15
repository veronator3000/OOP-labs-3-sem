using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidateComputer.ComponentСompatibility;

public class RamAndMotherboardFrequencyValidator : IComputerValidator
{
    private const string Message = "incompatible components. motherboard does not support ram frequency\n";

    public ValidateResult Validate(Computer computer)
    {
        computer = computer ?? throw new ArgumentNullException(nameof(computer));
        if (computer.RamComponent.Any(ram => ram.JedecAndVoltageRam.Voltage >
                                             computer.MotherboardComponent.ChipsetMotherBoard.AvailableMemoryFrequencies))
        {
            return new ValidateResult.IncompatibleСomponentsResult(Message);
        }

        return new ValidateResult.SuccsesfulBuildResult(computer);
    }
}