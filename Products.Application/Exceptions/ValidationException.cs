namespace Products.Application.Exceptions;
public class ValidationException : Exception
{
    public IReadOnlyCollection<ValidationError> Errors { get; }

    public ValidationException(IReadOnlyCollection<ValidationError> _errors)
    {
        Errors = _errors;
    }    
}

public record ValidationError (string PropertyName, string ErrorMessage, string ErrorCode);
