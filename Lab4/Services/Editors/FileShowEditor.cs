using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Output;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Editors;

public class FileShowEditor
{
    public WorkResult Run(WorkingDirectory directory, string address, string mode)
    {
        directory = directory ?? throw new ArgumentNullException(nameof(directory));
        address = address ?? throw new ArgumentNullException(nameof(address));
        IFile? file = directory.WorkingSpace?.FindFileByName(address);
        if (mode == "console")
        {
            var temp = new MajorDisplay(new ConsoleDisplayForContent());
            return file is null ? new WorkResult.NonExistentFile("file not found") : file.ReadContent(temp);
        }

        return new WorkResult.SuccessfulDataProcessing();
    }
}