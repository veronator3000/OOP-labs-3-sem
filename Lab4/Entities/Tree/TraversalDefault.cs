using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Tree;

public class TraversalDefault : ITree
{
    private readonly IVisitor _visitor;
    public TraversalDefault(
        WorkingDirectory rootDirectory,
        IVisitor visitor)
    {
        RootDirectory = rootDirectory;
        _visitor = visitor;
    }

    public WorkingDirectory RootDirectory { get; }
    public void Traversal(IDirectory currentDirectory, int depth)
    {
        currentDirectory = currentDirectory ?? throw new ArgumentNullException(nameof(currentDirectory));
        currentDirectory.InitDirectory(currentDirectory.Name);
        _visitor.Visit(currentDirectory, depth);
        foreach (IDirectory directory in currentDirectory.Directories)
        {
            Traversal(directory, depth);
        }
    }
}