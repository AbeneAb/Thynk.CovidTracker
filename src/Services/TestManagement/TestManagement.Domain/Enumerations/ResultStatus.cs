namespace TestManagement.Domain.Enumerations
{
    public class ResultStatus : Enumeration
    {
        public static ResultStatus Negative = new ResultStatus(1,nameof(Negative).ToLowerInvariant());
        public static ResultStatus Positive = new ResultStatus(2,nameof(Positive).ToLowerInvariant());
        public static ResultStatus Inconclusive = new ResultStatus(2, nameof(Inconclusive).ToLowerInvariant()); 
        public static IEnumerable<ResultStatus> List = new [] { Negative, Positive, Inconclusive };
        internal ResultStatus(int id, string name): base(id,name)
        {
        }
    }
}
