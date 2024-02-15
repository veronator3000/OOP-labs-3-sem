using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidateComputer.ComponentСompatibility;

public class CpuAndMotherboardBiosValidator : IComputerValidator
{
    private const string Message = "incompatible components. BIOS does not support processor\n";

    public ValidateResult Validate(Computer computer)
    {
        computer = computer ?? throw new ArgumentNullException(nameof(computer));
        if (!computer.MotherboardComponent.BiosVersion.CpuBiosSupport.Contains(computer.CpuComponent))
        {
            return new ValidateResult.IncompatibleСomponentsResult(Message);
        }

        return new ValidateResult.SuccsesfulBuildResult(computer);
    }
}