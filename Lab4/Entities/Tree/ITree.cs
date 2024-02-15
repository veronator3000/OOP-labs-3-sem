namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Tree;

public interface ITree
{
    WorkingDirectory RootDirectory { get; }
    void Traversal(IDirectory currentDirectory, int depth);
}