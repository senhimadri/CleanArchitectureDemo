using CleanArchitecture.Application.DTOs.LeaveAllocation;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveAllocation.Requests.Queries;

public class GetLeaveRequestListRequest : IRequest<List<LeaveAllocationDTO>>
{
}
