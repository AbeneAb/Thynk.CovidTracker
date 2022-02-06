namespace TestManagement.Domain.Enumerations
{
    public class SpecimenTypes : Enumeration
    {
        public static SpecimenTypes Nasopharyngeal = new SpecimenTypes(1,nameof(Nasopharyngeal).ToLowerInvariant());  
        public static SpecimenTypes AnteriorNares = new SpecimenTypes(2, nameof(AnteriorNares).ToLowerInvariant()); 
        public static SpecimenTypes NasalSwab = new SpecimenTypes(3,nameof(NasalSwab).ToLowerInvariant());
        public static IEnumerable<SpecimenTypes> List() => new[] { Nasopharyngeal, AnteriorNares,NasalSwab };
        private SpecimenTypes(int id, string name): base(id, name)
        {

        }
    }
}
