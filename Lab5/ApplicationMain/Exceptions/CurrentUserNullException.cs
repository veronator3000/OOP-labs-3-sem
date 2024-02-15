namespace ApplicationMain.Exceptions;

public class CurrentUserNullException : Exception
{
    public CurrentUserNullException(string message)
        : base(message)
    {
    }

    public CurrentUserNullException()
    {
    }

    public CurrentUserNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}