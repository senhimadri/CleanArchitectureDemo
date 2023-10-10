using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveAllocation;
using CleanArchitecture.Application.Features.LeaveAllocation.Requests.Queries;
using CleanArchitecture.Application.Contracts.Parsistence;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveAllocation.Handlers.Queries;

public class GetLeaveRequestDetailsRequestHandler : IRequestHandler<GetLeaveRequestDetailsRequest, LeaveAllocationDTO>
{
    private readonly ILeaveAllocationRepository _repository;
    private readonly IMapper _mapper;

    public GetLeaveRequestDetailsRequestHandler(ILeaveAllocationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<LeaveAllocationDTO> Handle(GetLeaveRequestDetailsRequest request, CancellationToken cancellationToken)
    {
        var leavetype = await _repository.GetLeaveAllocationWithDetailsAsync(request.Id);
        return _mapper.Map<LeaveAllocationDTO>(leavetype);
    }
}
