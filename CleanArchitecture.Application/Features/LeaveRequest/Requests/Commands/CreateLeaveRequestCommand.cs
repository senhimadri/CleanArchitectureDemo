using CleanArchitecture.Application.DTOs.LeaveRequest;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequest.Requests.Commands;

public class CreateLeaveRequestCommand:IRequest<int>
{
    public CreateLeaveRequestDTO CreateLeaveRequestDTO { get; set; }
}
