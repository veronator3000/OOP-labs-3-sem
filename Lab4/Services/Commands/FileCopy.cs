using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Editors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileCopy : ICommand
{
    public FileCopy(
        WorkingDirectory directory,
        string destinationPath,
        string sourcePath)
    {
        Directory = directory;
        DestinationPath = destinationPath;
        SourcePath = sourcePath;
        Editor = new FileCopyEditor();
    }

    public WorkingDirectory Directory { get; }
    private FileCopyEditor Editor { get; }
    private string SourcePath { get; }
    private string DestinationPath { get; }

    public WorkResult Execute()
    {
        return Editor.Run(Directory, SourcePath, DestinationPath);
    }
}