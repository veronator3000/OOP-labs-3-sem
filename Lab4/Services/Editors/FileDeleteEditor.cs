using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Editors;

public class FileDeleteEditor
{
    public WorkResult Run(WorkingDirectory directory, string path)
    {
        directory = directory ?? throw new ArgumentNullException(nameof(directory));
        IFile? file = directory.WorkingSpace?.FindFileByName(path);
        return file is null ? new WorkResult.NonExistentFile("file not found") : file.Delete();
    }
}