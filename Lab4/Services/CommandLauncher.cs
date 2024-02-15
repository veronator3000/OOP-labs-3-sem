using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class CommandLauncher
{
    private readonly IList<IParser> _handlersChain = new List<IParser>()
    {
        new ConnectHandler(),
        new DisconnectHandler(),
        new TreeGoHandler(),
        new TreeListHandler(),
        new FileShowHandler(),
        new FileMoveHandler(),
        new FileCopyHandler(),
        new FileDeleteHandler(),
        new FileRenameHandler(),
    };

    public WorkResult StartParse(string command, WorkingDirectory directory)
    {
        try
        {
            SettingHandlers();
            ICommand? commandTemp = _handlersChain[0].ParseCommand(command, directory);
            WorkResult? res1 = commandTemp?.Execute();
            return res1 ?? new WorkResult.FailedDataProcessing("impossible command execution");
        }
        catch (NonexistentCommandException)
        {
            return new WorkResult.IncorrectCommand("invalid command " + command);
        }
    }

    public void AddNewHandler(IParser newHandler)
    {
        _handlersChain.Add(newHandler);
    }

    private void SettingHandlers()
    {
        int chainSize = _handlersChain.Count;
        for (int i = 0; i < chainSize - 1; i++)
        {
            _handlersChain[i].SetNextHandler(_handlersChain[i + 1]);
        }
    }
}