namespace TestManagement.Domain.Enumerations
{
    public class UserRoles : Enumeration
    {
        public static UserRoles Client = new UserRoles(1, nameof(Client).ToLowerInvariant());
        public static UserRoles LabTechnician = new UserRoles(2, nameof(LabTechnician).ToLowerInvariant());
        public static UserRoles Admin = new UserRoles(3, nameof(Admin).ToLowerInvariant());
        public static IEnumerable<UserRoles> List() => new[] { Client, LabTechnician, Admin };
        internal UserRoles(int id, string name): base(id,name)
        {
        }
    }
}
