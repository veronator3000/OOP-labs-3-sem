namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

public abstract record WorkResult
{
    private WorkResult(string message)
    {
        Message = message;
    }

    public string Message { get; }

    public sealed record SuccessfulDataProcessing() : WorkResult(string.Empty);

    public sealed record FailedDataProcessing(string Message) : WorkResult(Message);
    public sealed record FailedMoveFile(string Message) : WorkResult(Message);
    public sealed record FailedRenameFile(string Message) : WorkResult(Message);
    public sealed record ExistingFile(string Message) : WorkResult(Message);
    public sealed record FailedCopyFile(string Message) : WorkResult(Message);
    public sealed record FailedReadContent(string Message) : WorkResult(Message);
    public sealed record FailedWriteContent(string Message) : WorkResult(Message);
    public sealed record FailedCreateFile(string Message) : WorkResult(Message);
    public sealed record FailedDeleteFile(string Message) : WorkResult(Message);
    public sealed record IncorrectCommand(string Message) : WorkResult(Message);
    public sealed record DisconnectState(string Message) : WorkResult(Message);
    public sealed record NonExistentFile(string Message) : WorkResult(Message);
}