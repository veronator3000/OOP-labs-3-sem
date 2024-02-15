using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Output;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Tree;

public class TraversalForOutput : ITree
{
    private readonly IVisitor _visitor;
    public TraversalForOutput(
        WorkingDirectory rootDirectory,
        IDisplayForTree displayForTree)
    {
        rootDirectory = rootDirectory ?? throw new ArgumentNullException(nameof(rootDirectory));
        RootDirectory = rootDirectory;
        _visitor = new VisitorForTreeOutput(displayForTree);
        CurrentDirectory = RootDirectory.WorkingSpace;
    }

    public WorkingDirectory RootDirectory { get; private set; }
    public IDirectory? CurrentDirectory { get; private set; }

    public void Traversal(IDirectory currentDirectory, int depth)
    {
        currentDirectory = currentDirectory ?? throw new ArgumentNullException(nameof(currentDirectory));
        _visitor.Visit(currentDirectory, depth);

        foreach (IFile file in currentDirectory.Files)
        {
            _visitor.Visit(file, depth + 1);
        }

        foreach (IDirectory subDirectory in currentDirectory.Directories)
        {
            Traversal(subDirectory, depth + 1);
        }
    }
}