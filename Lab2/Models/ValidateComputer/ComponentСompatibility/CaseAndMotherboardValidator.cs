using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidateComputer.ComponentСompatibility;

public class CaseAndMotherboardValidator : IComputerValidator
{
    private const string Message = "incompatible components. form factor of the motherboard and case are incompatible\n";

    public ValidateResult Validate(Computer computer)
    {
        computer = computer ?? throw new ArgumentNullException(nameof(computer));
        if (!computer.MotherboardComponent.MotherboardFormFactorType.Equals(computer.CaseComponent.CaseFormFactorName))
        {
            return new ValidateResult.IncompatibleСomponentsResult(Message);
        }

        return new ValidateResult.SuccsesfulBuildResult(computer);
    }
}