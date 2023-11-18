using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveAllocation.Validator;
using CleanArchitecture.Application.DTOs.LeaveRequest.Validator;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.LeaveAllocation.Requests.Commands;
using CleanArchitecture.Application.Contracts.Parsistence;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveAllocation.Handlers.Commands;

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
{
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;

    public CreateLeaveAllocationCommandHandler(IUnitofWork unitofWork, IMapper mapper)
    {
        _unitofWork = unitofWork;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveAllocationDTOValidator(_unitofWork.LeaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.LeaveAllocationDTO);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);

        var leaveallocation = _mapper.Map<Domain.LeaveAllocation>(request.LeaveAllocationDTO);
        leaveallocation = await _unitofWork.LeaveAllocationRepository.AddAsync(leaveallocation);
        await _unitofWork.Save();
        return leaveallocation.Id;
    }
}
