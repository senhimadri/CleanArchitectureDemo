using CleanArchitecture.Application.Parsistence.Contracts;
using FluentValidation;

namespace CleanArchitecture.Application.DTOs.LeaveRequest.Validator;

public class ILeaveRequestDTOValidator: AbstractValidator<IleaveRequestDTO>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public ILeaveRequestDTOValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
        RuleFor(x => x.StartDate)
            .LessThan(x => x.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}.");

        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.EndDate).WithMessage("{PropertyName} must be after {ComparisonValue}.");

        RuleFor(x => x.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var LeavetypeExit = await _leaveTypeRepository.ExistAsync(id);
                return !LeavetypeExit;
            }).WithMessage("{PropertyName} does not exist.");
    }
}
