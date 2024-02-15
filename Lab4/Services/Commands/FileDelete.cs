using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Editors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileDelete : ICommand
{
    public FileDelete(
        WorkingDirectory directory,
        string path)
    {
        Directory = directory;
        Path = path;
        Editor = new FileDeleteEditor();
    }

    public WorkingDirectory Directory { get; }
    private FileDeleteEditor Editor { get; }
    private string Path { get; }

    public WorkResult Execute()
    {
        return Editor.Run(Directory, Path);
    }
}