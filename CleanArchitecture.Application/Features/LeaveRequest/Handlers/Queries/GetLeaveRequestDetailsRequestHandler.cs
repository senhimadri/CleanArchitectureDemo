using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.DTOs.LeaveRequest;
using CleanArchitecture.Application.Features.LeaveRequest.Requests.Queries;
using CleanArchitecture.Application.Contracts.Parsistence;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequest.Handlers.Queries;

public class GetLeaveRequestDetailsRequestHandler : IRequestHandler<GetLeaveRequestDetailsRequest, LeaveRequestDTO>
{
    //private readonly ILeaveRequestRepository _repository;
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;

    public GetLeaveRequestDetailsRequestHandler(IUnitofWork unitofWork, IMapper mapper)
    {
        _unitofWork = unitofWork;
        _mapper = mapper;
    }
    public async Task<LeaveRequestDTO> Handle(GetLeaveRequestDetailsRequest request, CancellationToken cancellationToken)
    {
        var leavetype = await _unitofWork.LeaveRequestRepository.GetLeaveRequestWithDetailsAsync(request.Id);
        return _mapper.Map<LeaveRequestDTO>(leavetype);
    }
}
