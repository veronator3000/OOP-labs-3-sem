using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidateComputer.ComponentСompatibility;

public class RamAndMotherboardSlotsValidator : IComputerValidator
{
    private const string Message = "incompatible components. not enough ram slots\n";

    public ValidateResult Validate(Computer computer)
    {
        computer = computer ?? throw new ArgumentNullException(nameof(computer));
        if (computer.MotherboardComponent.RamSlots < computer.RamComponent.Count)
        {
            return new ValidateResult.IncompatibleСomponentsResult(Message);
        }

        return new ValidateResult.SuccsesfulBuildResult(computer);
    }
}