using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.DTOs.LeaveRequest;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequest.Requests.Queries;

public class GetLeaveRequestDetailsRequest : IRequest<LeaveRequestDTO>
{
    public int Id { get; set; }
}
