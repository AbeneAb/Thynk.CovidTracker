using TestManagement.Infrastructure.Repository;

namespace TestManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ThynkContext>(options => options.UseSqlServer(configuration.GetConnectionString("ThynkConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>),typeof(AsyncRepository<>));
            services.AddScoped<IAvailableCapacityRepository, AvailableCapacityRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IResultRepository, ResultRepository>();
            services.AddScoped<ISpecimenInformationRepository, SpecimenInformationRepository>();
            services.AddScoped<ITestCenterRepository, TestCenterRepository>();
            services.AddScoped<ITestCenterLogRepository, TestCenterLogRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
