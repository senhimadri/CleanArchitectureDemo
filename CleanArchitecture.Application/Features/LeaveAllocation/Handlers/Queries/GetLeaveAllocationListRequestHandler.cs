using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveAllocation;
using CleanArchitecture.Application.Features.LeaveAllocation.Requests.Queries;
using CleanArchitecture.Application.Contracts.Parsistence;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveAllocation.Handlers.Queries;

public class GetLeaveRequestListRequestHandler : IRequestHandler<GetLeaveRequestListRequest, List<LeaveAllocationDTO>>
{
    private readonly ILeaveAllocationRepository _repository;
    private readonly IMapper _mapper;

    public GetLeaveRequestListRequestHandler(ILeaveAllocationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<LeaveAllocationDTO>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
    {
        var leavetype = await _repository.GetLeaveAllocationsListWithDetailsAsync();
        return _mapper.Map<List<LeaveAllocationDTO>>(leavetype);
    }
}
