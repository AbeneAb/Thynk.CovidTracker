namespace TestManagement.Application.Queries.TestCenter;

public record TestCenterVM
{
    public Guid Id { get; set; }
    public string Name { get; init; }
    public uint Capacity { get; init; }
    public bool IsAvailable { get; init; }
    public DateTime AvailableFrom { get; init; }
    public DateTime AvailableUnitl { get; init; }
    public uint AvailableSpace { get; init; }
    public string? City { get; init; }
    public string? State { get; init; }
    public string? Street { get; init; }
    public string? ZipCode { get; init; }    
}
public record TestBookingReport
{
    public Guid Id { get; set; }
    public string TestCenter { get; init; }
    public string Capacity { get; init; }
    public int TotalBooking { get; init; }
    public int Positives { get; init; }
    public int Negatives { get; init; }
    public int Inconclusive { get; init; }

}

