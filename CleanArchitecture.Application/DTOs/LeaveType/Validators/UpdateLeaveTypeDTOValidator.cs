using FluentValidation;

namespace CleanArchitecture.Application.DTOs.LeaveType.Validators;

public class UpdateLeaveTypeDTOValidator: AbstractValidator<LeaveTypeDTO>
{
    public UpdateLeaveTypeDTOValidator()
    {
        Include(new ILeaveTypeDTOValidator());

        RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} must be present.");
    }
}
