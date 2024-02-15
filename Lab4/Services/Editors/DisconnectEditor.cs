using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Editors;

public class DisconnectEditor
{
    public WorkResult Run(WorkingDirectory workingDirectory)
    {
        workingDirectory = workingDirectory ?? throw new ArgumentNullException(nameof(workingDirectory));
        return workingDirectory.SetWorkingDirectory(null);
    }
}