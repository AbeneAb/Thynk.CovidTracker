namespace TestManagement.Domain.Entities
{
    public class User : EntityBase
    {
        public string FirstName { get; private set; }   
        public string LastName { get; private set; }
        public DateOnly DOB { get; private set; }
        public string Email { get; private set; }
        public string Telephone { get; private set; }   
        public Gender Gender { get; set; } = Gender.NotSpecicifed;

        public User(string firstName, string lastName, DateOnly dob,string email,string telephone, int gender)
        {
            FirstName = firstName;
            LastName = lastName;
            DOB = dob;
            Email = email;
            Telephone = telephone;
            Gender = Enumeration.FromValue<Gender>(gender);

        }
    }
}
