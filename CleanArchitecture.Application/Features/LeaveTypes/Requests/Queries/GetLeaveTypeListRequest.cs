using CleanArchitecture.Application.DTOs;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveTypes.Requests.Queries;

public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDTO>>
{
}
