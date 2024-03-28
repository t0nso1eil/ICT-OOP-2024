namespace MentallHealthSupport.Application.Exceptions;

public class IncorrectInputException : Exception
{
    public IncorrectInputException(string message = "Not found") : base(message) { }
}