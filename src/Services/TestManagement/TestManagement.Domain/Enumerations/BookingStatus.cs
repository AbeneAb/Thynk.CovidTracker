namespace TestManagement.Domain.Enumerations
{
    public class BookingStatus : Enumeration
    {
        public static BookingStatus Reserved = new BookingStatus(1, nameof(Reserved).ToLowerInvariant());
        public static BookingStatus Canceled = new BookingStatus(2,nameof(Canceled).ToLowerInvariant());
        public static BookingStatus Completed = new BookingStatus(3,nameof(Completed).ToLowerInvariant());  
        public static IEnumerable<BookingStatus> List() => new [] { Reserved, Canceled,Completed };

        public BookingStatus(int id,string name):base(id,name)  
        {

        }
    }
}
