using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Features.LeaveTypes.Requests.Queries;
using CleanArchitecture.Application.Parsistence.Contracts;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveTypes.Handlers.Queries;

public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDTO>>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public GetLeaveTypeListRequestHandler(ILeaveTypeRepository leaveTypeRepository,IMapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<List<LeaveTypeDTO>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
    {
        var leavetype = await _leaveTypeRepository.GetAllAsync();
        return _mapper.Map<List<LeaveTypeDTO>>(leavetype);
    }
}
