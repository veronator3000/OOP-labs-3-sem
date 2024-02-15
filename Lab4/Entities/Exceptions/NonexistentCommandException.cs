using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Exceptions;

public class NonexistentCommandException : Exception
{
    public NonexistentCommandException(string message)
        : base(message)
    {
    }

    public NonexistentCommandException()
    {
    }

    public NonexistentCommandException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}