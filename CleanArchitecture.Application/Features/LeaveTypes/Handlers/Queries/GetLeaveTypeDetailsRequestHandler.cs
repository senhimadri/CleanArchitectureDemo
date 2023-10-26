using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveType;
using CleanArchitecture.Application.Features.LeaveTypes.Requests.Queries;
using CleanArchitecture.Application.Contracts.Parsistence;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveTypes.Handlers.Queries;

public class GetLeaveTypeDetailsRequestHandler : IRequestHandler<GetLeaveTypeDetailsRequest, LeaveTypeDTO>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public GetLeaveTypeDetailsRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }
    public async Task<LeaveTypeDTO> Handle(GetLeaveTypeDetailsRequest request, CancellationToken cancellationToken)
    {
        var leavetype = await _leaveTypeRepository.GetAsync(request.Id);
        return _mapper.Map<LeaveTypeDTO>(leavetype);
    }
}
