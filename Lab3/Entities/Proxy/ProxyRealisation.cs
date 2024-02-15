using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Proxy;

public class ProxyRealisation : IRecipient
{
    private IRecipient _recipient;

    public ProxyRealisation(IRecipient recipient)
    {
        recipient = recipient ?? throw new ArgumentNullException(nameof(recipient));
        _recipient = recipient;
    }

    public int MinPriority { get; set; }

    public void ObtainingMessage(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        if (message.ImportanceLevel >= MinPriority)
        {
            _recipient.ObtainingMessage(message);
        }
    }

    public void SetMinimumPriority(int priority)
    {
        MinPriority = priority;
    }
}