namespace Application;

public class ApplicationValidationException : Exception
{
    public List<ValidationError> Errors { get; set; }
    
    public ApplicationValidationException(string message) : base(message)
    {
    }
    
    public ApplicationValidationException(string titulo, string mensagem) : base(mensagem)
    {
        Errors = new List<ValidationError> { new (titulo, mensagem) };
    }
    
    public ApplicationValidationException(IEnumerable<ValidationError> validationErrors)
    {
        Errors = validationErrors.ToList();
    }
    
    public ApplicationValidationException(IEnumerable<ValidationError> validationErrors, string message) : base(message)
    {
        Errors = validationErrors.ToList();
    }
}