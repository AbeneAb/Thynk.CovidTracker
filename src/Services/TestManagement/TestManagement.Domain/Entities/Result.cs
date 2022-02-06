namespace TestManagement.Domain.Entities
{
    public class Result : EntityBase
    {
        public Guid BookingId { get; set; }
        public ResultStatus Status { get; set; } = ResultStatus.Inconclusive;
        public DateTime ResultIssuedDate { get; private set; } = DateTime.Now;

    }
}
