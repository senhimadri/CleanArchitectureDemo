using AutoMapper;
using CleanArchitecture.Application.Features.LeaveRequest.Requests.Commands;
using CleanArchitecture.Application.Parsistence.Contracts;
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
            throw new Exception("Not Found");

        await _repository.DeleteAsync(leaverequest.Id);

        return Unit.Value;
    }
}
