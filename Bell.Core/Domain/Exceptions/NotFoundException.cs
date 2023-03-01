namespace Bell.Core.Domain.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name) : base($"'{name}' could not be found.") { }
}
