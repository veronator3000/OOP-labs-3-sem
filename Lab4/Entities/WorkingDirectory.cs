using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class WorkingDirectory
{
    public WorkingDirectory(IDirectory? workingSpace)
    {
        WorkingSpace = workingSpace;
    }

    public IDirectory? WorkingSpace { get; private set; }
    public WorkResult SetWorkingDirectory(IDirectory? workingDirectory)
    {
        WorkingSpace = workingDirectory;
        if (WorkingSpace is not null && workingDirectory is not null)
        {
            return WorkingSpace.InitDirectory(workingDirectory.Name);
        }

        WorkingSpace?.Directories.Clear();
        WorkingSpace?.Files.Clear();

        return new WorkResult.SuccessfulDataProcessing();
    }
}