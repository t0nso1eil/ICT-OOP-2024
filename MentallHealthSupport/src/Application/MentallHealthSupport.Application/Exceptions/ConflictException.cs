namespace MentallHealthSupport.Application.Exceptions;

public class ConflictException : Exception
{
    public ConflictException(string message = "Conflict") : base(message) { }
}