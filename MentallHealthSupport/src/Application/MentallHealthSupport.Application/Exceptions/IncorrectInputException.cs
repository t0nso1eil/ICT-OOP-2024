namespace MentallHealthSupport.Application.Exceptions;

public class IncorrectInputException : Exception
{
    public IncorrectInputException(string message = "Incorrect Input") : base(message) { }
}