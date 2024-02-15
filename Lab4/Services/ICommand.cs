using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public interface ICommand
{
    WorkingDirectory? Directory { get; }
    WorkResult Execute();
}