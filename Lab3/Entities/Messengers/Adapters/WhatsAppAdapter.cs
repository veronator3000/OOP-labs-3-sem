using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers.ThirdPartyIntegration;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers.Adapters;

public class WhatsAppAdapter : IMessenger
{
    private readonly IWhatsApp _whatsApp;
    private readonly IList<StatusMessage> _messages = new List<StatusMessage>();

    public WhatsAppAdapter(IWhatsApp whatsApp)
    {
        whatsApp = whatsApp ?? throw new ArgumentNullException(nameof(whatsApp));
        _whatsApp = whatsApp;
    }

    public void SendMessage(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        _whatsApp.Post(string.Empty, string.Empty, message.Body);
        var savedMessages = new StatusMessage(message);
        _messages.Add(savedMessages);
    }
}