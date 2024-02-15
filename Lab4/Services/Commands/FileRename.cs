using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Editors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileRename : ICommand
{
    public FileRename(
        WorkingDirectory directory,
        string path,
        string newName)
    {
        Directory = directory;
        Path = path;
        NewName = newName;
        Editor = new FileRenameEditor();
    }

    public WorkingDirectory Directory { get; }
    private FileRenameEditor Editor { get; }
    private string Path { get; }
    private string NewName { get; }

    public WorkResult Execute()
    {
        return Editor.Run(Directory, Path, NewName);
    }
}