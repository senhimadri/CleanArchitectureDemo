﻿using AutoMapper;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.LeaveAllocation.Requests.Commands;
using CleanArchitecture.Application.Contracts.Parsistence;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveAllocation.Handlers.Commands;

public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
{
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;

    public DeleteLeaveAllocationCommandHandler(IUnitofWork unitofWork, IMapper mapper)
    {
        _unitofWork = unitofWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var leaveallocation = await _unitofWork.LeaveAllocationRepository.GetAsync(request.Id);
        if (leaveallocation is null)
            throw new NotFoundException(name: nameof(Domain.LeaveAllocation), key: request.Id);

        await _unitofWork.LeaveAllocationRepository.DeleteAsync(leaveallocation);
        await _unitofWork.Save();

        return Unit.Value;
    }
}
