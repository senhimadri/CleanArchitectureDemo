using CleanArchitecture.Application.DTOs.LeaveRequest;
using CleanArchitecture.Application.Responses;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequest.Requests.Commands;

public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
{
    public CreateLeaveRequestDTO CreateLeaveRequestDTO { get; set; }
}
