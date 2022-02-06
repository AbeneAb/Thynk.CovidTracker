namespace TestManagement.Domain.Entities
{
    public class SpecimenInformation : EntityBase
    {
        public Guid BookingId { get; private set; }
        public Guid TestCenterId { get; private set; }  
        public DateTime CollectionDate { get; private set; }
        public SpecimenTypes SpecimenTypes { get; private set; } = SpecimenTypes.Nasopharyngeal;
        public SpecimenInformation(Guid bookingId,Guid testCenterId, DateTime collectionDate,string specimenType) :base()
        {
            BookingId = bookingId;
            TestCenterId = testCenterId;
            CollectionDate = collectionDate;
            SpecimenTypes =  Enumeration.FromDispalyName<SpecimenTypes>(specimenType);
        }

    }
}
