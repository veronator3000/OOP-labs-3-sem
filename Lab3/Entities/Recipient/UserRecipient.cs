using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public class UserRecipient : IRecipient
{
    private readonly IList<StatusMessage> _messages = new List<StatusMessage>();

    public IList<StatusMessage> GetListOfMessage => new List<StatusMessage>(_messages);

    public void ObtainingMessage(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        var savedMessages = new StatusMessage(message);
        _messages.Add(savedMessages);
    }

    public void MarkMessageAsRead(int index)
    {
        if (_messages[index].Status)
        {
             throw new InvalidReadingMessageException("message has already been read");
        }

        if (index >= 0 && index < _messages.Count)
        {
            _messages[index].ReadMessage(true);
        }
        else
        {
            throw new InvalidReadingMessageException("non-existent message");
        }
    }
}