using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidateComputer.ComponentСompatibility;

public class CpuAndMotherboardSocketValidator : IComputerValidator
{
    private const string Message = "incompatible components. motherboard socket does not fit the processor socket\n";

    public ValidateResult Validate(Computer computer)
    {
        computer = computer ?? throw new ArgumentNullException(nameof(computer));
        if (!computer.CpuComponent.CpuSocketName.Equals(computer.MotherboardComponent.CpuSocketName))
        {
            return new ValidateResult.IncompatibleСomponentsResult(Message);
        }

        return new ValidateResult.SuccsesfulBuildResult(computer);
    }
}