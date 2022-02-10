namespace TestManagement.Domain.Enumerations
{
    public class BookingStatus : Enumeration
    {
        public static BookingStatus Reserved = new BookingStatus(1, nameof(Reserved).ToLowerInvariant());
        public static BookingStatus Canceled = new BookingStatus(2,nameof(Canceled).ToLowerInvariant());
        public static BookingStatus Completed = new BookingStatus(3,nameof(Completed).ToLowerInvariant());
        public static BookingStatus InProgress = new BookingStatus(4, nameof(InProgress).ToLowerInvariant());

        public static IEnumerable<BookingStatus> List() => new [] { Reserved, Canceled,Completed,InProgress };

        public BookingStatus(int id,string name):base(id,name)  
        {

        }
        public static BookingStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new DomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
