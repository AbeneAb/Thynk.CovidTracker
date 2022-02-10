namespace TestManagement.Domain.Enumerations
{
    public class ResultStatus : Enumeration
    {
        public static ResultStatus Pending = new ResultStatus(1, nameof(Pending).ToLowerInvariant());
        public static ResultStatus Negative = new ResultStatus(2,nameof(Negative).ToLowerInvariant());
        public static ResultStatus Positive = new ResultStatus(3,nameof(Positive).ToLowerInvariant());
        public static ResultStatus Inconclusive = new ResultStatus(4, nameof(Inconclusive).ToLowerInvariant()); 
        public static IEnumerable<ResultStatus> List() => new [] {Pending, Negative, Positive, Inconclusive };
        internal ResultStatus(int id, string name): base(id,name)
        {
        }
        public static ResultStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new DomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
