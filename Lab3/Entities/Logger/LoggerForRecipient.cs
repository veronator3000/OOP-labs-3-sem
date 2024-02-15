using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Logger;

public class LoggerForRecipient : IRecipient
{
    private ILogger _logger;
    private IRecipient _recipient;

    public LoggerForRecipient(
        ILogger logger,
        IRecipient recipient)
    {
        logger = logger ?? throw new ArgumentNullException(nameof(logger));
        recipient = recipient ?? throw new ArgumentNullException(nameof(recipient));
        _logger = logger;
        _recipient = recipient;
    }

    public void ObtainingMessage(Message message)
    {
        _recipient.ObtainingMessage(message);
        if (_logger.LoggerActive)
        {
            _logger.LogMessage(message, _recipient);
        }
    }
}