using CleanArchitecture.Application.Contracts.Parsistence;
using FluentValidation;

namespace CleanArchitecture.Application.DTOs.LeaveRequest.Validator;

public class UpdateLeaveRequestDTOValidator : AbstractValidator<UpdateLeaveRequestDTO>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public UpdateLeaveRequestDTOValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        Include(new ILeaveRequestDTOValidator(_leaveTypeRepository));

        RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
    }
}
