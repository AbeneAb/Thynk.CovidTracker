namespace TestManagement.Domain.Entities
{
    public class User : EntityBase
    {
        public string FirstName { get; private set; }   
        public string LastName { get; private set; }
        public DateTime DOB { get; private set; }
        public string Email { get; private set; }
        public string Telephone { get; private set; }
        private int _genderId;
        public Gender Gender { get; set; } = Gender.NotSpecicifed;
        private int _roleId;
        public UserRoles UserRole { get; set; }
        public ICollection<Booking> Bookings { get; private set; }  
        public ICollection<TestCenterLog> TestCenterLogs { get; private set; }
        public User()
        {
            Bookings = new List<Booking>();
            TestCenterLogs = new List<TestCenterLog>();
        }

        public User(string firstName, string lastName, DateTime dob, string email, string telephone, int gender,int role)
        {
            FirstName = firstName;
            LastName = lastName;
            DOB = dob;
            Email = email;
            Telephone = telephone;
            _genderId = gender;
            _roleId = role;
        }

    }
}
