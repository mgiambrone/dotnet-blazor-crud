using FluentValidation;

namespace Blazorcrud.Shared.Models
{
    public class CISSTaskValidator : AbstractValidator<CISSTask>
    {
        public CISSTaskValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(task => task.TaskName).NotEmpty().WithMessage("Has to be one of the selected tasks")
                .Length(5, 50).WithMessage("File name must be between 5 and 50 characters.");
        }
    }
}