using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public class GroupRecipient : IRecipient
{
    private readonly IList<IRecipient> _recipients;

    public GroupRecipient(
        IList<IRecipient> recipients)
    {
        _recipients = recipients;
    }

    public void ObtainingMessage(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        foreach (IRecipient recipient in _recipients)
        {
            recipient.ObtainingMessage(message);
        }
    }
}