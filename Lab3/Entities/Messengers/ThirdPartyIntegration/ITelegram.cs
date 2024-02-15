namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers.ThirdPartyIntegration;

public interface ITelegram
{
    void SendingMessage(string apiKey, long userId, string message);
}