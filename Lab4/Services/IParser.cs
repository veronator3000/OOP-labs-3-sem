using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public interface IParser
{
    IParser? Handler { get; }
    ICommand? ParseCommand(string command, WorkingDirectory directory);
    void SetNextHandler(IParser nextHandler);
}