using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.ResultWorkDisplay;

public class ConsoleResultWorkDisplay : IResultWorkDisplay
{
    public string Output(WorkResult result)
    {
        result = result ?? throw new ArgumentNullException(nameof(result));
        Console.WriteLine(result.Message);
        return result.Message;
    }
}