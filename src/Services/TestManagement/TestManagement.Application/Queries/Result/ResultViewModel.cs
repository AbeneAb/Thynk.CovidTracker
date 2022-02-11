namespace TestManagement.Application.Queries.Result;

public record ResultVM 
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }    
    public string Result { get; init; }
    public string TestCenter { get; init; }

    
}
