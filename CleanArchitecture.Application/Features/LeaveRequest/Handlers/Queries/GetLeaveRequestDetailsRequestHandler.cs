using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.DTOs.LeaveRequest;
using CleanArchitecture.Application.Features.LeaveRequest.Requests.Queries;
using CleanArchitecture.Application.Parsistence.Contracts;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequest.Handlers.Queries;

public class GetLeaveRequestDetailsRequestHandler : IRequestHandler<GetLeaveRequestDetailsRequest, LeaveRequestDTO>
{
    private readonly ILeaveRequestRepository _repository;
    private readonly IMapper _mapper;

    public GetLeaveRequestDetailsRequestHandler(ILeaveRequestRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<LeaveRequestDTO> Handle(GetLeaveRequestDetailsRequest request, CancellationToken cancellationToken)
    {
        var leavetype = await _repository.GetLeaveRequestWithDetailsAsync(request.Id);
        return _mapper.Map<LeaveRequestDTO>(leavetype);
    }
}
