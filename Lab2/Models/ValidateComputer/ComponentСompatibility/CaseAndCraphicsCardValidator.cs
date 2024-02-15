using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidateComputer.ComponentСompatibility;

public class CaseAndCraphicsCardValidator : IComputerValidator
{
    private const string Message = "incompatible components. video card does not fit the case in size \n";

    public ValidateResult Validate(Computer computer)
    {
        computer = computer ?? throw new ArgumentNullException(nameof(computer));
        if (computer.GpuComponent is not null)
        {
            if (computer.GpuComponent.LenghtGraphicsCard > computer.CaseComponent.CaseLenght ||
                computer.GpuComponent.WidthGraphicsCard > computer.CaseComponent.CaseLenght)
            {
                return new ValidateResult.IncompatibleСomponentsResult(Message);
            }
        }

        return new ValidateResult.SuccsesfulBuildResult(computer);
    }
}