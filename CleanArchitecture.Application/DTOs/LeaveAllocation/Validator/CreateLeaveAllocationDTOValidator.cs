using CleanArchitecture.Application.DTOs.LeaveType.Validators;
using CleanArchitecture.Application.Parsistence.Contracts;
using FluentValidation;

namespace CleanArchitecture.Application.DTOs.LeaveAllocation.Validator;

public class CreateLeaveAllocationDTOValidator:AbstractValidator<CreateLeaveAllocationDTO>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public CreateLeaveAllocationDTOValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
        Include(new ILeaveAllocationDTOValidator(_leaveTypeRepository));
    }
}
