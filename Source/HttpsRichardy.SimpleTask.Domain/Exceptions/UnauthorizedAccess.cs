namespace HttpsRichardy.SimpleTask.Domain.Exceptions;

public class UnauthorizedAccessException : Exception
{
    public UnauthorizedAccessException()
        : base("Unauthorized access.") {  }

    public UnauthorizedAccessException(string message)
        : base(message) {  }

    public UnauthorizedAccessException(string message, Exception innerException)
        : base(message, innerException) {  }
}