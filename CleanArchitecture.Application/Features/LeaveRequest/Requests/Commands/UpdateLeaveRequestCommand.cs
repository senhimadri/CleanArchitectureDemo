using CleanArchitecture.Application.DTOs.LeaveRequest;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequest.Requests.Commands;

public class UpdateLeaveRequestCommand :IRequest<Unit>
{
    public UpdateLeaveRequestDTO LeaveRequestDTO { get; set; }
}
