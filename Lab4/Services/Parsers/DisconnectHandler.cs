using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class DisconnectHandler : IParser
{
    public IParser? Handler { get; private set; }
    public ICommand? ParseCommand(string command, WorkingDirectory directory)
    {
        return string.Equals(command, "disconnect", StringComparison.OrdinalIgnoreCase) ? new Disconnect(directory) : Handler?.ParseCommand(command, directory);
    }

    public void SetNextHandler(IParser nextHandler)
    {
        Handler = nextHandler;
    }
}