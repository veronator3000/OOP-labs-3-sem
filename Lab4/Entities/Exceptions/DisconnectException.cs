using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Exceptions;

public class DisconnectException : Exception
{
    public DisconnectException(string message)
        : base(message)
    {
    }

    public DisconnectException()
    {
    }

    public DisconnectException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}