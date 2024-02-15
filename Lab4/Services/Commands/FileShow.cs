using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Editors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileShow : ICommand
{
    public FileShow(
        WorkingDirectory directory,
        string mode,
        string address)
    {
        Directory = directory;
        Mode = mode;
        Address = address;
        Editor = new FileShowEditor();
    }

    public WorkingDirectory Directory { get; }
    private string Mode { get; }
    private FileShowEditor Editor { get; }
    private string Address { get; }

    public WorkResult Execute()
    {
        return Editor.Run(Directory, Address, Mode);
    }
}