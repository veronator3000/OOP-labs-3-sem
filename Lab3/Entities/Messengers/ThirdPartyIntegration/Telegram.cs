using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers.ThirdPartyIntegration;

public class Telegram : ITelegram
{
    public void SendingMessage(string apiKey, long userId, string message)
    {
        Console.WriteLine("[Telegram] " + message);
    }
}