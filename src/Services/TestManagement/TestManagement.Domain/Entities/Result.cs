namespace TestManagement.Domain.Entities
{
    public class Result : EntityBase
    {
        public Guid BookingId { get; set; }
        public Guid SpecimenId { get; set; }
        private int _resultStatusId;
        public ResultStatus Status { get; set; } = ResultStatus.Inconclusive;
        public DateTime? ResultIssuedDate { get; private set; } = DateTime.Now;
        public Booking Booking { get; set; }
        public Result()
        {

        }
        public Result(Guid bookingId,DateTime? resultIssuedDate):base()
        {
            BookingId = bookingId;
            ResultIssuedDate = resultIssuedDate;
            _resultStatusId = ResultStatus.Pending.Id;
        }

    }
}
