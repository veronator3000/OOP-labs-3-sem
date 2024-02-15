using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Editors;

public class FileMoveEditor
{
    public WorkResult Run(string sourcePath, string destinationPath, WorkingDirectory directory)
    {
        sourcePath = sourcePath ?? throw new ArgumentNullException(nameof(sourcePath));
        destinationPath = destinationPath ?? throw new ArgumentNullException(nameof(destinationPath));
        directory = directory ?? throw new ArgumentNullException(nameof(directory));

        IFile? fileToMove = directory.WorkingSpace?.FindFileByName(sourcePath);
        return fileToMove is null ? new WorkResult.NonExistentFile("file not found") : fileToMove.MoveContent(destinationPath);
    }
}