using CleanArchitecture.Application.DTOs.LeaveType;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveTypes.Requests.Queries;

public class GetLeaveAllocationListRequest : IRequest<List<LeaveTypeDTO>>
{
}
