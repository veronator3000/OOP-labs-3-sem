using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models.ResultWorkDisplay;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

public class WorkResultRepo
{
    private readonly IList<WorkResult> _workResults = new List<WorkResult>();
    public WorkResultRepo(IResultWorkDisplay resultWorkDisplay)
    {
        ResultWorkOutputer = resultWorkDisplay;
    }

    private IResultWorkDisplay ResultWorkOutputer { get; }

    public void GetWorkResult(WorkResult workResult)
    {
        workResult = workResult ?? throw new ArgumentNullException(nameof(workResult));
        _workResults.Add(workResult);
    }

    public void SeeResults()
    {
        foreach (WorkResult result in _workResults)
        {
            ResultWorkOutputer.Output(result);
        }
    }
}