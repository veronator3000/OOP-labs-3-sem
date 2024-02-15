using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Logger;

public class LoggerRealisation : ILogger
{
    public bool LoggerActive { get; set; }

    public void LogMessage(Message message, IRecipient recipient)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        Console.WriteLine($"\n {message.Title}\n {message.Body}\n {DateTime.Now}");
    }
}