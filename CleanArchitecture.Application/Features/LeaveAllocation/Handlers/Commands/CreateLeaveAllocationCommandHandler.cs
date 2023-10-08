using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveAllocation.Validator;
using CleanArchitecture.Application.DTOs.LeaveRequest.Validator;
using CleanArchitecture.Application.Features.LeaveAllocation.Requests.Commands;
using CleanArchitecture.Application.Parsistence.Contracts;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveAllocation.Handlers.Commands;

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
{
    private readonly ILeaveAllocationRepository _LeaveAllocationRepository;
    private readonly ILeaveTypeRepository _LeaveTypeRepository;
    private readonly IMapper _mapper;

    public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository LeaveAllocationRepository,ILeaveTypeRepository LeaveTypeRepository, IMapper mapper)
    {
        _LeaveAllocationRepository = LeaveAllocationRepository;
        _LeaveTypeRepository = LeaveTypeRepository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveAllocationDTOValidator(_LeaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.LeaveAllocationDTO);
        if (!validationResult.IsValid)
            throw new Exception();

        var leaveallocation = _mapper.Map<Domain.LeaveAllocation>(request.LeaveAllocationDTO);
        leaveallocation = await _LeaveAllocationRepository.AddAsync(leaveallocation);
        return leaveallocation.Id;
    }
}
