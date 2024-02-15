using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Editors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class Connect : ICommand
{
    public Connect(
        string mode,
        string address1,
        WorkingDirectory? directory)
    {
        Editor = new ConnectEditor();
        Mode = mode;
        Path = address1;
        Directory = directory;
    }

    public WorkingDirectory? Directory { get; }
    private ConnectEditor Editor { get; }
    private string Mode { get; }
    private string Path { get; }
    public WorkResult Execute()
    {
        return Editor.Run(Directory, Mode, Path);
    }
}