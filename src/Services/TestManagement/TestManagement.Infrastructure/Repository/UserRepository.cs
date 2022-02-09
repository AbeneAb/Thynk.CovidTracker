namespace TestManagement.Infrastructure.Repository
{
    public class UserRepository : AsyncRepository<User>, IUserRepository
    {
        public UserRepository(ThynkContext thynkContext):base(thynkContext)
        {

        }
    }
}
