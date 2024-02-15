using Itmo.ObjectOrientedProgramming.Lab4.Entities.Output;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Tree;

public class VisitorForTreeOutput : IVisitor
{
    private readonly MajorDisplay _displayForTree;

    public VisitorForTreeOutput(IDisplayForTree displayForTree)
    {
        _displayForTree = new MajorDisplay(displayForTree);
    }

    public void Visit(IDirectory directory, int depth)
    {
        _displayForTree.Output(directory, depth);
    }

    public void Visit(IFile file, int depth)
    {
        _displayForTree.Output(file, depth);
    }
}
