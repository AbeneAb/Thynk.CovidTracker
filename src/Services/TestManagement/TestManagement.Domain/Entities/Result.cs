namespace TestManagement.Domain.Entities
{
    public class Result : EntityBase
    {
        public Guid BookingId { get; set; }
        public Guid SpecimenId { get; set; }
        private int _resultStatusId;
        public ResultStatus Status { get; private set; }
        public DateTime? ResultIssuedDate { get; private set; } = DateTime.Now;
        public Booking Booking { get; set; }
        public Result()
        {

        }
        public Result(Guid bookingId,DateTime? resultIssuedDate,Guid specimenId):base()
        {
            BookingId = bookingId;
            ResultIssuedDate = resultIssuedDate;
            SpecimenId = specimenId;
            _resultStatusId = ResultStatus.Pending.Id;
        }
        public void SetResultStatus(int statusId) 
        {
            _resultStatusId=statusId;   
        }
        public void SetResultPositive() 
        {
            _resultStatusId = ResultStatus.Positive.Id;
        }
        public void SetNegative() 
        {
            _resultStatusId = ResultStatus.Negative.Id;
        }
        public void SetInconclusive() 
        {
            _resultStatusId = ResultStatus.Inconclusive.Id;
        }

    }
}
