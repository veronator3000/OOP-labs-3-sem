namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Output;

public class MajorDisplay
{
    private readonly IDisplayForTree? _displayForTree;
    private readonly IDisplayForContent? _displayForContent;

    public MajorDisplay(IDisplayForTree displayForTree, IDisplayForContent displayForContent)
    {
        _displayForTree = displayForTree;
        _displayForContent = displayForContent;
    }

    public MajorDisplay(IDisplayForContent displayForContent)
    {
        _displayForTree = null;
        _displayForContent = displayForContent;
    }

    public MajorDisplay(IDisplayForTree displayForTree)
    {
        _displayForTree = displayForTree;
        _displayForContent = null;
    }

    public void Output(string message)
    {
        _displayForContent?.Output(message);
    }

    public void Output(IDirectory directory, int depth)
    {
        _displayForTree?.Output(directory, depth);
    }

    public void Output(IFile file, int depth)
    {
        _displayForTree?.Output(file, depth);
    }
}