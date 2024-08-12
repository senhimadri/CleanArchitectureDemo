using CleanArchitecture.Application.Contracts.Parsistence;
using FluentValidation;

namespace CleanArchitecture.Application.DTOs.LeaveAllocation.Validator;

public class UpdateLeaveAllocationDTOValidator : AbstractValidator<UpdateLeaveAllocationDTO>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public UpdateLeaveAllocationDTOValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
        Include(new ILeaveAllocationDTOValidator(_leaveTypeRepository));

        RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
    }
}
