namespace TestManagement.Application.Commands.TestCenter
{
    public class CreateTestCenterCommandValidator : AbstractValidator<CreateTestCenterCommand>
    {
        public CreateTestCenterCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{Test Center Name} is required")
                .NotNull().MaximumLength(400).WithMessage("Length must not exceed 400 character");
            RuleFor(c => c.Capacity).NotNull().NotEmpty().WithMessage("Specify Capacity");
            RuleFor(c => c.AvailableFrom).NotNull().NotEmpty();
            RuleFor(c=>c.AvailableUntil).NotEmpty().NotEmpty();
            RuleFor(c => c.AvailableUntil).GreaterThan(c => c.AvailableFrom).WithMessage("Time Anomaly detected");
            RuleFor(c => c.AvailableSpace).NotNull().NotEmpty().LessThan(c => c.Capacity).WithMessage("Available space has to be lessthan Capacity");
        }
    }
}
