using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;

public class Topic : ITopic
{
    private readonly IRecipient _recipient;

    public Topic(
        IRecipient recipient,
        string name)
    {
        name = name ?? throw new ArgumentNullException(nameof(name));
        _recipient = recipient;
        Name = name;
    }

    public string Name { get; }

    public void ForwardMessage(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        _recipient.ObtainingMessage(message);
    }
}