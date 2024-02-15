using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Editors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class TreeList : ICommand
{
    public TreeList(int depth, WorkingDirectory directory)
    {
        Depth = depth;
        Directory = directory;
        Editor = new TreeListEditor();
    }

    public WorkingDirectory Directory { get; }

    private TreeListEditor Editor { get; }

    private int Depth { get; }

    public WorkResult Execute()
    {
        return Editor.Run(Directory, Depth);
    }
}