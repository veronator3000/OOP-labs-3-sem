using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient.Drivers;

public class DisplayRecipient : IRecipient
{
    private readonly IList<Message> _messages = new List<Message>();
    private readonly ConsoleColor _consoleColor;
    private readonly IDisplayDriver _displayDriverRecipient;

    public DisplayRecipient(ConsoleColor consoleColor)
    {
        _displayDriverRecipient = new DisplayDriverRecipient();
        _consoleColor = consoleColor;
    }

    public void ObtainingMessage(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        if (_messages.Count == 1)
        {
            _messages.Clear();
            _messages.Add(message);
            return;
        }

        _messages.Add(message);
    }

    public void DisplayCurrentMessage()
    {
        if (_messages.Count != 0)
        {
            Console.ForegroundColor = _consoleColor;
            Console.WriteLine(_messages[0].Body);
        }
    }

    public void CleanFlow()
    {
        _displayDriverRecipient.CleanFlow();
    }

    public void MakeColorText(ConsoleColor textColor)
    {
        _displayDriverRecipient.MakeColorText(textColor);
    }
}
