using CleanArchitecture.Application.DTOs;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveAllocation.Requests.Queries;

public class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDTO>>
{
}
