namespace HttpsRichardy.SimpleTask.Domain.Exceptions;

public class ObjectDoesNotExistException : Exception
{
    public ObjectDoesNotExistException()
        : base("The object does not exist.") {  }

    public ObjectDoesNotExistException(string message)
        : base(message) {  }

    public ObjectDoesNotExistException(string message, Exception innerException)
        : base(message, innerException) {  }
}
