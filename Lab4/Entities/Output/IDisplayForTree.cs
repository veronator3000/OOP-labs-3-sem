namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Output;

public interface IDisplayForTree
{
    DisplayOptions DisplayOptions { get; }
    void Output(IDirectory directory, int depth);
    void Output(IFile file, int depth);
}