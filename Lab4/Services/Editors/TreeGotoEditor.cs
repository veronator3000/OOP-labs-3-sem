using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Editors;

public class TreeGotoEditor
{
    public WorkResult Run(WorkingDirectory directory, string path)
    {
        directory = directory ?? throw new ArgumentNullException(nameof(directory));
        path = path ?? throw new ArgumentNullException(nameof(path));

        WorkResult? res1 = directory.WorkingSpace?.SetAnotherWorkingPlace(path);
        if (directory.WorkingSpace is null)
        {
            return new WorkResult.FailedDataProcessing("failed");
        }

        return res1 is null ? new WorkResult.FailedDataProcessing("error") : directory.WorkingSpace.SetAnotherWorkingPlace(path);
    }
}