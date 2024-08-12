using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveAllocation.Validator;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.LeaveAllocation.Requests.Commands;
using CleanArchitecture.Application.Contracts.Parsistence;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveAllocation.Handlers.Commands;

public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
{
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;

    public UpdateLeaveAllocationCommandHandler(IUnitofWork unitofWork, IMapper mapper)
    {
        _unitofWork = unitofWork;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateLeaveAllocationDTOValidator(_unitofWork.LeaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.LeaveAllocationDTO);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);

        var leaveallocation = await _unitofWork.LeaveAllocationRepository.GetAsync(request.LeaveAllocationDTO.Id);
        _mapper.Map(request.LeaveAllocationDTO, leaveallocation);
        await _unitofWork.LeaveAllocationRepository.UpdateAsync(leaveallocation);
        await _unitofWork.Save();
        return Unit.Value;
    }
}
