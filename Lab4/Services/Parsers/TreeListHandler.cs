using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class TreeListHandler : IParser
{
    public IParser? Handler { get; private set; }
    public ICommand? ParseCommand(string command, WorkingDirectory directory)
    {
        command = command ?? throw new ArgumentNullException(nameof(command));
        string[] parts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 4 && string.Equals(parts[0], "tree", StringComparison.OrdinalIgnoreCase)
                              && string.Equals(parts[2], "-d", StringComparison.OrdinalIgnoreCase))
        {
            if (int.TryParse(parts[3], out int depth) && depth >= 0)
            {
                return new TreeList(depth, directory);
            }
        }

        if (parts.Length == 2 && string.Equals(parts[0], "tree", StringComparison.OrdinalIgnoreCase))
        {
            int depth = 1;
            return new TreeList(depth, directory);
        }

        return Handler?.ParseCommand(command, directory);
    }

    public void SetNextHandler(IParser nextHandler)
    {
        Handler = nextHandler;
    }
}