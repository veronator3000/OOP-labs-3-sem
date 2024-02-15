using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Output;

public class ConsoleDisplayForTree : IDisplayForTree
{
    private readonly HashSet<IFile> _printedFiles = new HashSet<IFile>();
    private readonly HashSet<IDirectory> _printedDirectories = new HashSet<IDirectory>();

    public ConsoleDisplayForTree(DisplayOptions displayOptions)
    {
        displayOptions = displayOptions ?? throw new ArgumentNullException(nameof(displayOptions));
        DisplayOptions = displayOptions;
    }

    public DisplayOptions DisplayOptions { get; }

    public void Output(IDirectory directory, int depth)
    {
        directory = directory ?? throw new ArgumentNullException(nameof(directory));
        string indent = new string(' ', depth * 4);
        if (_printedDirectories.Contains(directory))
        {
            return;
        }

        Console.WriteLine($"{indent}{DisplayOptions.DirectoryIcon} {directory.Name}");
        _printedDirectories.Add(directory);

        foreach (IFile file in directory.Files)
        {
            Output(file, depth + 1);
        }

        foreach (IDirectory subDirectory in directory.Directories)
        {
            Output(subDirectory, depth + 1);
        }
    }

    public void Output(IFile file, int depth)
    {
        file = file ?? throw new ArgumentNullException(nameof(file));
        if (_printedFiles.Contains(file))
        {
            return;
        }

        string indent = new string(' ', depth * 3);
        Console.WriteLine($"{indent}    {DisplayOptions.FileIcon} {file.Name}");
        _printedFiles.Add(file);
    }
}
