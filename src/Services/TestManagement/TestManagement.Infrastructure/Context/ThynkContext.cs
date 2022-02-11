using TestManagement.Domain.QueryModel;

namespace TestManagement.Infrastructure
{
    public class ThynkContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "covid";
        public const string ENUM_SCHEMA = "enum";
        public DbSet<Booking> Bookings { get; set; }    
        public DbSet<Result> Results { get; set; }
        public DbSet<SpecimenInformation> Specimens { get; set; }
        public DbSet<TestCenter> Tests { get; set; }
        public DbSet<TestCenterAvailableCapacity> TestsAvailableCapacity { get; set; }
        public DbSet<TestCenterLog> TestCenterLogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookingStatus> BookingStatuses { get; set; }
        public DbSet<Gender> Genders { get; set; }  
        public DbSet<ResultStatus> ResultsStatus { get; set; }
        public DbSet<SpecimenTypes> SpecimenTypes { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<TestCenterBookingReport> TestCenterBookingReports { get; set; }
        private readonly IMediator _mediator; 
        private IDbContextTransaction _transaction;
        public ThynkContext(DbContextOptions<ThynkContext> options):base(options)
        {

        }
        public ThynkContext(DbContextOptions<ThynkContext> contextOptions, IMediator mediator) : base(contextOptions)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
