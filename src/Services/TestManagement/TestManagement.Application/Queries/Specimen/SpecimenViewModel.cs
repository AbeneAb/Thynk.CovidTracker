namespace TestManagement.Application.Queries.Specimen;

public record SpecimenVM 
{
    public Guid BookingId { get; set; }
    public DateTime BookingDate { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid SpecimenId { get; set; }
    public string SpecimenType { get; set; }
    public DateTime SpecimenCollectionDate { get; set; }

}
