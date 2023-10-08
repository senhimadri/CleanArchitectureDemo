using FluentValidation;

namespace CleanArchitecture.Application.DTOs.LeaveType.Validators;

public class CreateLeaveTypeDTOValidator: AbstractValidator<LeaveTypeDTO>
{
    public CreateLeaveTypeDTOValidator()
    {
        Include(new ILeaveTypeDTOValidator());
    }
}
