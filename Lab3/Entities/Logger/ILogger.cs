using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Logger;

public interface ILogger
{
    bool LoggerActive { get; set; }
    void LogMessage(Message message, IRecipient recipient);
}