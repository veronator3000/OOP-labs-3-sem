using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers.Adapters;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public abstract class MessengerRecipient : IRecipient
{
    private readonly IMessenger _messenger;

    protected MessengerRecipient(IMessenger messenger)
    {
        messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
        _messenger = messenger;
    }

    public void ObtainingMessage(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        _messenger.SendMessage(message);
    }
}