namespace TestManagement.Domain.Interfaces
{
    public interface ISpecimenInformationRepository : IAsyncRepository<SpecimenInformation>
    {
        Task<IEnumerable<SpecimenInformation>> GetAllSpecimensInprogressAsync();
    }
}
