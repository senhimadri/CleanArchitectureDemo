using CleanArchitecture.Application.DTOs.LeaveType;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveTypes.Requests.Queries;

public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDTO>>
{
}
