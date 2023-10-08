using AutoMapper;
using CleanArchitecture.Application.Features.LeaveRequest.Requests.Commands;
using CleanArchitecture.Application.Parsistence.Contracts;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequest.Handlers.Commands;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository _repository;
    private readonly IMapper _mapper;

    public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaverequest = await _repository.GetAsync(request.RequestId);

        if (request.LeaveRequestDTO is not null)
        {
            _mapper.Map(request.LeaveRequestDTO, leaverequest);
            await _repository.UpdateAsync(leaverequest);
        }
        else if(request.ChangeLeaveRequestApprovalDTO is not null)
        {
            await _repository.ChangeApprovalStatus(leaverequest, request.ChangeLeaveRequestApprovalDTO.IsApproved);
        }

        return Unit.Value;
    }
}
