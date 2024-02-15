using Itmo.ObjectOrientedProgramming.Lab4.Entities.Output;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public interface IFile
{
    string Name { get; }
    WorkResult ReadContent(MajorDisplay display);
    WorkResult WriteContent(string text);
    WorkResult Delete();
    WorkResult MoveContent(string destinationDirectory);
    WorkResult RenameFile(string newName);
    WorkResult CopyFile(string destinationDirectory);
}