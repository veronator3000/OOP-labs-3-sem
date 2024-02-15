using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidateComputer;

public abstract record ValidateResult
{
    private ValidateResult() { }

    public sealed record SuccsesfulBuildResult(Computer Computer) : ValidateResult;

    public sealed record IncompatibleСomponentsResult(string Message) : ValidateResult;

    public sealed record WarningWithoutGuaranteeResult(Computer Computer, string Warning) : ValidateResult;
}