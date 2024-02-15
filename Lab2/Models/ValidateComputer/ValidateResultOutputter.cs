using System;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidateComputer;

public sealed record ValidateResultOutputter
{
    public string ValidationStatus(ComputerBuilder computerBuilder)
    {
        computerBuilder = computerBuilder ?? throw new ArgumentNullException(nameof(computerBuilder));
        if (computerBuilder.ValidateResults[0] is ValidateResult.SuccsesfulBuildResult)
        {
            return $"suc build";
        }

        if (computerBuilder.ValidateResults[0] is ValidateResult.IncompatibleСomponentsResult)
        {
            string temp = string.Empty;
            foreach (ValidateResult.IncompatibleСomponentsResult validationResult in computerBuilder.ValidateResults)
            {
                temp += validationResult.Message;
            }

            return temp;
        }

        if (computerBuilder.ValidateResults[0] is ValidateResult.WarningWithoutGuaranteeResult)
        {
            string temp = string.Empty;
            foreach (ValidateResult.WarningWithoutGuaranteeResult validationResult in computerBuilder.ValidateResults)
            {
                temp += validationResult.Warning;
            }

            return temp;
        }

        return $"noway";
    }
}