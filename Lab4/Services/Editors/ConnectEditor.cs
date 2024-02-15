using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.LocalFileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Editors;

public class ConnectEditor
{
    public WorkResult Run(WorkingDirectory? directory, string mode, string path)
    {
        directory = directory ?? throw new ArgumentNullException(nameof(directory));
        mode = mode ?? throw new ArgumentNullException(nameof(mode));
        path = path ?? throw new ArgumentNullException(nameof(path));
        if (mode == "local")
        {
            var newDirectory = new DirectoryLocal(path);
            return directory.SetWorkingDirectory(newDirectory);
        }

        return new WorkResult.SuccessfulDataProcessing();

        // здесь можно добавить логику для фс кроме локальной
    }
}