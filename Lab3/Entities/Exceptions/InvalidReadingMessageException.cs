using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Exceptions;

public class InvalidReadingMessageException : Exception
{
    public InvalidReadingMessageException(string message)
        : base(message)
    {
    }

    public InvalidReadingMessageException()
    {
    }

    public InvalidReadingMessageException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}