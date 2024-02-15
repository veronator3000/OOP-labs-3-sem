using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Output;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Tree;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Editors;

public class TreeListEditor
{
    public WorkResult Run(WorkingDirectory directory, int depth)
    {
        var outputOptions = new DisplayOptions();
        outputOptions.SetOutputOptions("🐱", "📁");

        var treeForOutput = new TraversalForOutput(directory, new ConsoleDisplayForTree(outputOptions));
        if (directory.WorkingSpace is not null)
        {
            treeForOutput.Traversal(directory.WorkingSpace, depth);
            return new WorkResult.SuccessfulDataProcessing();
        }

        return new WorkResult.FailedDataProcessing("failed");
    }
}