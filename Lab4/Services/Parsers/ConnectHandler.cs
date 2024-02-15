using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class ConnectHandler : IParser
{
    public IParser? Handler { get; private set; }
    public ICommand? ParseCommand(string command, WorkingDirectory? directory)
    {
        command = command ?? throw new ArgumentNullException(nameof(command));
        directory = directory ?? throw new ArgumentNullException(nameof(directory));

        string[] parts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 4 && parts[0] == "connect" && parts[2] == "-m")
        {
            if (parts[3] == "local")
            {
                return new Connect(parts[3], parts[1], directory);
            }

            if (parts[3] == "in-memory")
            {
                return new Connect(parts[3], parts[1], directory);
            }
        }

        if (directory.WorkingSpace is null)
        {
            throw new DisconnectException();
        }

        return Handler?.ParseCommand(command, directory);
    }

    public void SetNextHandler(IParser nextHandler)
    {
        Handler = nextHandler;
    }
}