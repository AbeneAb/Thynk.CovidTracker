namespace TestManagement.Domain.Entities
{
    public class SpecimenInformation : EntityBase
    {
        public Guid BookingId { get; private set; }
        public DateTime CollectionDate { get; private set; }
        private int _specimenTypeId;
        public SpecimenTypes SpecimenTypes { get; private set; } = SpecimenTypes.Nasopharyngeal;
        public Booking Booking { get; private set; }
        public SpecimenInformation()
        {

        }
        public SpecimenInformation(Guid bookingId, DateTime collectionDate,int specimenType) :base()
        {
            BookingId = bookingId;
            CollectionDate = collectionDate;
            _specimenTypeId = specimenType;
        }

    }
}
