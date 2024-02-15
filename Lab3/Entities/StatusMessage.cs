using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class StatusMessage
{
    public StatusMessage(
        Message messages)
    {
        messages = messages ?? throw new ArgumentNullException(nameof(messages));
        Messages = messages;
    }

    public Message Messages { get; private set; }
    public bool Status { get; private set; }

    public void ReadMessage(bool readMessage)
    {
        Status = readMessage;
    }
}