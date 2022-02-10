namespace TestManagement.Application.Commands.SpecimenInformation
{
    public class CreateSpecimenCommand : IRequest<Guid>
    {
        public Guid BookingId { get; set; }
        public DateTime CollectionDate { get; set; }
        public int SpecimenTypeId { get; set; }
    }
}
