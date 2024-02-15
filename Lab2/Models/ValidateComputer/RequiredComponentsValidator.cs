using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidateComputer;

public class RequiredComponentsValidator : IComputerValidator
{
    private const string Message1 = "processor must have a video core or the computer must have a video card\n";
    private const string Message2 = "network equipment conflict\n";

    public ValidateResult Validate(Computer computer)
    {
        computer = computer ?? throw new ArgumentNullException(nameof(computer));
        if (!computer.CpuComponent.GraphicsCore && computer.GpuComponent is null)
        {
            return new ValidateResult.IncompatibleСomponentsResult(Message1);
        }

        if (computer.MotherboardComponent.WifiMotherboard is not null && computer.WifiComponent is not null)
        {
            return new ValidateResult.IncompatibleСomponentsResult(Message2);
        }

        return new ValidateResult.SuccsesfulBuildResult(computer);
    }
}