using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Editors;

public class FileCopyEditor
{
    public WorkResult Run(WorkingDirectory workingDirectory, string sourcePath, string destinationPath)
    {
        workingDirectory = workingDirectory ?? throw new ArgumentNullException(nameof(workingDirectory));
        IFile? file = workingDirectory.WorkingSpace?.FindFileByName(sourcePath);
        WorkResult? res1 = file?.CopyFile(destinationPath);
        return res1 ?? new WorkResult.NonExistentFile("file not found");
    }
}