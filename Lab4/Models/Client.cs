using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models.ResultWorkDisplay;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public class Client
{
    private readonly ExecutionResultsCollector _executionResultsCollector = new ExecutionResultsCollector(new ConsoleResultWorkDisplay());
    private readonly WorkingDirectory _workingDirectory = new WorkingDirectory(null);

    public void InputCommand()
    {
        while (true)
        {
            string? command = Console.ReadLine();
            if (command == null || command.ToUpperInvariant() == "escape" || command == "stop")
            {
                break;
            }

            _executionResultsCollector.Run(command, _workingDirectory);
        }
    }
}