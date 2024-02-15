using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers.ThirdPartyIntegration;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers.Adapters;

public class TelegramAdapter : IMessenger
{
    private readonly ITelegram _telegram;
    private readonly IList<StatusMessage> _messages = new List<StatusMessage>();
    public TelegramAdapter(ITelegram telegram)
    {
        telegram = telegram ?? throw new ArgumentNullException(nameof(telegram));
        _telegram = telegram;
    }

    public void SendMessage(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        _telegram.SendingMessage(string.Empty, 0, message.Body);
        var savedMessages = new StatusMessage(message);
        _messages.Add(savedMessages);
    }
}