using CleanArchitecture.Application.DTOs.LeaveRequest;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequest.Requests.Queries;

public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestDTO>>
{
}
