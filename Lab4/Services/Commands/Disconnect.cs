using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Editors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class Disconnect : ICommand
{
    public Disconnect(WorkingDirectory directory)
    {
        Editor = new DisconnectEditor();
        Directory = directory;
    }

    public WorkingDirectory Directory { get; }
    private DisconnectEditor Editor { get; }

    public WorkResult Execute()
    {
        return Editor.Run(Directory);
    }
}