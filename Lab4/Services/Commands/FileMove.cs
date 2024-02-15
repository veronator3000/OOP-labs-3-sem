using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Editors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileMove : ICommand
{
    public FileMove(
        string sourcePath,
        string destinationPath,
        WorkingDirectory directory)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
        Directory = directory;
        Editor = new FileMoveEditor();
    }

    public WorkingDirectory Directory { get; }
    private FileMoveEditor Editor { get; }
    private string SourcePath { get; }
    private string DestinationPath { get; }
    public WorkResult Execute()
    {
        return Editor.Run(SourcePath, DestinationPath, Directory);
    }
}