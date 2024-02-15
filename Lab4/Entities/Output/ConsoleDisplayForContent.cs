using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Output;

public class ConsoleDisplayForContent : IDisplayForContent
{
    public void Output(string content)
    {
        Console.WriteLine(content);
    }
}