using CleanArchitecture.Application.Contracts.Parsistence;
using FluentValidation;

namespace CleanArchitecture.Application.DTOs.LeaveAllocation.Validator;

public class ILeaveAllocationDTOValidator : AbstractValidator<ILeaveAllocationDTO>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public ILeaveAllocationDTOValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(p => p.NumberOfDays)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.");

        RuleFor(p => p.Period)
            .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}.");

        RuleFor(x => x.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var LeavetypeExit = await _leaveTypeRepository.ExistAsync(id);
                return LeavetypeExit;
            }).WithMessage("{PropertyName} does not exist.");
    }


}
