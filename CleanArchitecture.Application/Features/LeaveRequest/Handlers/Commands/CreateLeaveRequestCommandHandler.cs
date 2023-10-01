using CleanArchitecture.Domain;
using AutoMapper;
using CleanArchitecture.Application.Features.LeaveRequest.Requests.Commands;
using CleanArchitecture.Application.Parsistence.Contracts;
using MediatR;
using CleanArchitecture.Application.DTOs.LeaveType;

namespace CleanArchitecture.Application.Features.LeaveRequest.Handlers.Commands;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
{
    private readonly ILeaveRequestRepository _repository;
    private readonly IMapper _mapper;

    public CreateLeaveRequestCommandHandler(ILeaveRequestRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaverequest = _mapper.Map<Domain.LeaveRequest>(request.CreateLeaveRequestDTO);
        leaverequest = await _repository.AddAsync(leaverequest);
        return leaverequest.Id;
    }
}
