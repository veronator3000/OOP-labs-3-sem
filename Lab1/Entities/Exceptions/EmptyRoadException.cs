using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Exceptions;

public class EmptyRoadException : Exception
{
    public EmptyRoadException(string message)
        : base(message)
    {
    }

    public EmptyRoadException()
    {
    }

    public EmptyRoadException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}