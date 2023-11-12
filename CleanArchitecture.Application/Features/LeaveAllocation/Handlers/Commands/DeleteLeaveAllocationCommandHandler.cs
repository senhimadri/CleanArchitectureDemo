using AutoMapper;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.LeaveAllocation.Requests.Commands;
using CleanArchitecture.Application.Contracts.Parsistence;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveAllocation.Handlers.Commands;

public class DeleteLeaveAllocationCommandHandler :IRequestHandler<DeleteLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _repository;
    private readonly IMapper _mapper;

    public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var leaveallocation = await _repository.GetAsync(request.Id);
        if (leaveallocation is null)
            throw new NotFoundException(name: nameof(Domain.LeaveAllocation), key: request.Id);

        await _repository.DeleteAsync(leaveallocation);

        return Unit.Value;
    }
}
