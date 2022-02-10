namespace TestManagement.Application.Commands.Result
{
    public class UpdateResultCommand : IRequest
    {
        public Guid Id { get; set; }
        public int Result { get; set; } 
    }
}
