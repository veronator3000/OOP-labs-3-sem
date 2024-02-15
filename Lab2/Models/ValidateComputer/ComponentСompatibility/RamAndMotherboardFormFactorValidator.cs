using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidateComputer.ComponentСompatibility;

public class RamAndMotherboardFormFactorValidator : IComputerValidator
{
    private const string Message = "incompatible components. form factor of motherboard and ram does not match\n";

    public ValidateResult Validate(Computer computer)
    {
        computer = computer ?? throw new ArgumentNullException(nameof(computer));
        if (computer.RamComponent.Any(ram =>
                !ram.RamFormFactorType.Equals(computer.MotherboardComponent.MotherboardFormFactorType)))
        {
            return new ValidateResult.IncompatibleСomponentsResult(Message);
        }

        return new ValidateResult.SuccsesfulBuildResult(computer);
    }
}