namespace TestManagement.Infrastructure.Context
{
    public class ThynkContextSeed
    {
        public static async Task SeedAsync(ThynkContext context,ILogger<ThynkContextSeed> logger) 
        {
            if (!context.BookingStatuses.Any()) 
            {
                context.BookingStatuses.AddRange(BookingStatus.List());
            }
            if (!context.ResultsStatus.Any()) 
            {
                context.ResultsStatus.AddRange(ResultStatus.List());
            }
            if (!context.Genders.Any()) 
            {
                context.Genders.AddRange(Gender.List());
            }
            if (!context.UserRoles.Any()) 
            {
                context.UserRoles.AddRange(UserRoles.List());
            }
            if (!context.SpecimenTypes.Any()) 
            {
                context.SpecimenTypes.AddRange(SpecimenTypes.List());
            }
            if (!context.Users.Any()) 
            {
                context.Users.AddRange(Users());
            }
            await context.SaveChangesAsync();
        }
        public static List<User> Users() 
        {
            User jane = new User("Jane", "Doe", new DateTime(1974, 11, 4), "jane@doe.com", "+9113323290", Gender.Female.Id, UserRoles.Client.Id);
            User Admin = new User("Admin","Admin", new DateTime(2000,3,3),"admin@admin","e",Gender.NotSpecicifed.Id,UserRoles.Admin.Id);
            User labAdmin = new User("Lab", "Admin", new DateTime(2000, 3, 3), "labadmin@admin", "e", Gender.NotSpecicifed.Id, UserRoles.LabTechnician.Id);

            return new List<User> { jane, Admin,labAdmin };
        }
    }
}
