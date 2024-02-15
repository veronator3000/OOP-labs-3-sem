using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient.Drivers;

public interface IDisplayDriver
{
    void CleanFlow();
    void MakeColorText(ConsoleColor textColor);
}