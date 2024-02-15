using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

public class FileRenameHandler : IParser
{
    public IParser? Handler { get; private set; }

    public ICommand? ParseCommand(string command, WorkingDirectory directory)
    {
        command = command ?? throw new ArgumentNullException(nameof(command));
        directory = directory ?? throw new ArgumentNullException(nameof(directory));
        string[] parts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 4 && parts[0] == "file"
                              && parts[1] == "rename")
        {
            string fullPath = GetAbsolutePath(parts[2], directory);
            return new FileRename(directory, fullPath, parts[3]);
        }

        throw new NonexistentCommandException("noway from rename");
    }

    public void SetNextHandler(IParser nextHandler)
    {
        Handler = nextHandler;
    }

    private string GetAbsolutePath(string path, WorkingDirectory directory)
    {
        if (directory.WorkingSpace is not null)
        {
            return Path.Combine(directory.WorkingSpace.Name, path);
        }

        return string.Empty;
    }
}