using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequest.Requests.Commands;

public class DeleteLeaveRequestCommand :IRequest
{
    public int Id { get; set; }
}
