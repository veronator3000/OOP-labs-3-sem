using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidateComputer.ComponentСompatibility;

public class CpuAndCoolerSocketValidator : IComputerValidator
{
    private const string Message = "incompatible components. unsupported cooling system socket\n";

    public ValidateResult Validate(Computer computer)
    {
        computer = computer ?? throw new ArgumentNullException(nameof(computer));
        if (!computer.CoolingSystemComponent.ValidSocketsForCooler.Contains(computer.CpuComponent.CpuSocketName))
        {
            return new ValidateResult.IncompatibleСomponentsResult(Message);
        }

        return new ValidateResult.SuccsesfulBuildResult(computer);
    }
}