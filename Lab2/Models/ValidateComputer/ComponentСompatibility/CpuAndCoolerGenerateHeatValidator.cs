using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidateComputer.ComponentСompatibility;

public class CpuAndCoolerGenerateHeatValidator : IComputerValidator
{
    private const string Message = "no guarantee. weak cooling system\n";

    public ValidateResult Validate(Computer computer)
    {
        computer = computer ?? throw new ArgumentNullException(nameof(computer));
        if (computer.CpuComponent.GenerateHeat >= computer.CoolingSystemComponent.Tdp)
        {
            return new ValidateResult.WarningWithoutGuaranteeResult(computer, Message);
        }

        return new ValidateResult.SuccsesfulBuildResult(computer);
    }
}