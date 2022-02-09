using TestManagement.Domain.Interfaces;

namespace TestManagement.Infrastructure.Repository
{
    public class SpecimenInformationRepository : AsyncRepository<SpecimenInformation>, ISpecimenInformationRepository
    {
        public SpecimenInformationRepository(ThynkContext thynkContext) : base(thynkContext)
        {

        }
    }
}
