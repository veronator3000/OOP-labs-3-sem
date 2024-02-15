namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Tree;

public interface IVisitor
{
    void Visit(IDirectory directory, int depth);
    void Visit(IFile file, int depth);
}