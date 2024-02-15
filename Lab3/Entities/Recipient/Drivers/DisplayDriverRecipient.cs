using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient.Drivers;

public class DisplayDriverRecipient : IDisplayDriver
{
    public void CleanFlow()
    {
        Console.Clear();
    }

    public void MakeColorText(ConsoleColor textColor)
    {
        Console.ForegroundColor = textColor;
    }
}