using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Features.LeaveAllocation.Requests.Queries;
using CleanArchitecture.Application.Parsistence.Contracts;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveAllocation.Handlers.Queries;

public class GetLeaveAllocationListRequestHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDTO>>
{
    private readonly ILeaveAllocationRepository _repository;
    private readonly IMapper _mapper;

    public GetLeaveAllocationListRequestHandler(ILeaveAllocationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<LeaveAllocationDTO>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
    {
        var leavetype = await _repository.GetAllAsync();
        return _mapper.Map<List<LeaveAllocationDTO>>(leavetype);
    }
}
