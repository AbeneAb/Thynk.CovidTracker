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
            if (context.ResultsStatus.Any()) 
            {
                var data = Enumeration.GetAll<ResultStatus>();
                context.ResultsStatus.AddRange(Enumeration.GetAll<ResultStatus>());
            }
            if (context.Genders.Any()) 
            {
            }
            await context.SaveChangesAsync();
        }
    }
}
