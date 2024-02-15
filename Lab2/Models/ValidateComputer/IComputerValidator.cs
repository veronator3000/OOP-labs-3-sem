using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidateComputer;

public interface IComputerValidator
{
    ValidateResult Validate(Computer computer);
}