using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

public class ObjectNotFoundInStorageException : Exception
{
    public ObjectNotFoundInStorageException(string message)
        : base(message)
    {
    }

    public ObjectNotFoundInStorageException()
    {
    }

    public ObjectNotFoundInStorageException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}