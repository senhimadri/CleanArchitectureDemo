using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.DTOs.LeaveRequest;
using CleanArchitecture.Application.Features.LeaveRequest.Requests.Queries;
using CleanArchitecture.Application.Contracts.Parsistence;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequest.Handlers.Queries;

public class GetLeaveRequestListRequestHandler : IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestDTO>>
{
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;

    public GetLeaveRequestListRequestHandler(IUnitofWork unitofWork, IMapper mapper)
    {
        _unitofWork = unitofWork;
        _mapper = mapper;
    }

    public async Task<List<LeaveRequestDTO>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
    {
        var leavetype = await _unitofWork.LeaveRequestRepository.GetLeaveRequestListWithDetailsAsync();
        return _mapper.Map<List<LeaveRequestDTO>>(leavetype);
    }
}
