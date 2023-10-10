using CleanArchitecture.Application.Contracts.Parsistence;
using FluentValidation;

namespace CleanArchitecture.Application.DTOs.LeaveRequest.Validator;

public class CreateLeaveRequestDTOValidator: AbstractValidator<CreateLeaveRequestDTO>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public CreateLeaveRequestDTOValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        Include(new ILeaveRequestDTOValidator(_leaveTypeRepository));
    }

}
