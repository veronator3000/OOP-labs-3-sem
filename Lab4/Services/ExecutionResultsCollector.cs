using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Models.ResultWorkDisplay;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class ExecutionResultsCollector
{
    private readonly CommandLauncher _commandLauncher = new CommandLauncher();
    private readonly WorkResultRepo _repo;

    public ExecutionResultsCollector(IResultWorkDisplay workDisplay)
    {
        WorkDisplay = workDisplay;
        _repo = new WorkResultRepo(workDisplay);
    }

    public IResultWorkDisplay WorkDisplay { get; set; }

    public void Run(string command, WorkingDirectory workingDirectory)
    {
        _repo.GetWorkResult(_commandLauncher.StartParse(command, workingDirectory));
        _repo.SeeResults();
    }
}