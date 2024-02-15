using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Editors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class TreeGoTo : ICommand
{
    public TreeGoTo(
        WorkingDirectory directory,
        string destinationPlace)
    {
        Directory = directory;
        DestinationPlace = destinationPlace;
        Editor = new TreeGotoEditor();
    }

    public WorkingDirectory Directory { get; }
    private TreeGotoEditor Editor { get; }
    private string DestinationPlace { get; }

    public WorkResult Execute()
    {
        return Editor.Run(Directory, DestinationPlace);
    }
}