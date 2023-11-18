using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveType;
using CleanArchitecture.Application.Features.LeaveTypes.Requests.Queries;
using CleanArchitecture.Application.Contracts.Parsistence;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveTypes.Handlers.Queries;

public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDTO>>
{
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;

    public GetLeaveTypeListRequestHandler(IUnitofWork unitofWork, IMapper mapper)
    {
        _unitofWork = unitofWork;
        _mapper = mapper;
    }

    public async Task<List<LeaveTypeDTO>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
    {
        var leavetype = await _unitofWork.LeaveTypeRepository.GetAllAsync();
        return _mapper.Map<List<LeaveTypeDTO>>(leavetype);
    }
}
