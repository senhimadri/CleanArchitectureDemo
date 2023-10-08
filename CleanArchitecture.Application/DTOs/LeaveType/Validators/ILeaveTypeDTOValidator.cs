using FluentValidation;

namespace CleanArchitecture.Application.DTOs.LeaveType.Validators;

public class ILeaveTypeDTOValidator:AbstractValidator<ILeaveTypeDTO>
{
    public ILeaveTypeDTOValidator()
    {
        RuleFor(p => p.Name)
       .NotEmpty().WithMessage("{PropertyName} is required.")
       .NotNull()
       .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 character.");

        RuleFor(p => p.DefaultDays)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0")
                .LessThan(100).WithMessage("{PropertyName} must be less than 0");
    }
}
