using AutoMapper;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.LeaveRequest.Requests.Commands;
using CleanArchitecture.Application.Parsistence.Contracts;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequest.Handlers.Commands;

public class DeleteLeaveRequestCommandHandler :IRequestHandler<DeleteLeaveRequestCommand>
{
    private readonly ILeaveRequestRepository _repository;
    private readonly IMapper _mapper;

    public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaverequest = await _repository.GetAsync(request.Id);
        if (leaverequest is null)
            throw new NotFoundException(name: nameof(Domain.LeaveRequest), key: request.Id);

        await _repository.DeleteAsync(leaverequest);

        return Unit.Value;
    }
}
