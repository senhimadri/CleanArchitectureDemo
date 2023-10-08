using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveAllocation.Validator;
using CleanArchitecture.Application.Features.LeaveAllocation.Requests.Commands;
using CleanArchitecture.Application.Parsistence.Contracts;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveAllocation.Handlers.Commands;

public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _LeaveAllocationRepository;
    private readonly ILeaveTypeRepository _LeaveTypeRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository LeaveAllocationRepository, ILeaveTypeRepository LeaveTypeRepository, IMapper mapper)
    {
        _LeaveAllocationRepository = LeaveAllocationRepository;
        _LeaveTypeRepository = LeaveTypeRepository;
        _mapper = mapper;
    }
    public  async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateLeaveAllocationDTOValidator(_LeaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.LeaveAllocationDTO);
        if (!validationResult.IsValid)
            throw new Exception();

        var leaveallocation = await _LeaveAllocationRepository.GetAsync(request.LeaveAllocationDTO.Id);
        _mapper.Map(request.LeaveAllocationDTO, leaveallocation);
        await _LeaveAllocationRepository.UpdateAsync(leaveallocation);
        return Unit.Value;
    }
}
