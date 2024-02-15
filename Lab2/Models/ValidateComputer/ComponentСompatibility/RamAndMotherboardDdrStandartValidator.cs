using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidateComputer.ComponentСompatibility;

public class RamAndMotherboardDdrStandartValidator : IComputerValidator
{
    private const string Message = "incompatible components. ddr standard motherboard and ram are incompatible\n";

    public ValidateResult Validate(Computer computer)
    {
        computer = computer ?? throw new ArgumentNullException(nameof(computer));
        if (computer.RamComponent.Any(ram => !ram.DdrStandartVersion.Equals(computer.MotherboardComponent.DdrStandartVersion)))
        {
            return new ValidateResult.IncompatibleСomponentsResult(Message);
        }

        return new ValidateResult.SuccsesfulBuildResult(computer);
    }
}