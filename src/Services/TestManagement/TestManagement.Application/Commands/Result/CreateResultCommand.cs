namespace TestManagement.Application.Commands.Result
{
    public class CreateResultCommand : IRequest<Guid>
    {
        public Guid BookingId { get; set; }
        public Guid SpecimenId { get; set; }
        public DateTime? ResultIssuedDate { get;  set; }
        public int ResultStatusId { get; set; }
    }
}
