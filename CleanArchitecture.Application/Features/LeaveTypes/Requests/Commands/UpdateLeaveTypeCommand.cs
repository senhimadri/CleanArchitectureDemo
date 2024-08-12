using CleanArchitecture.Application.DTOs.LeaveType;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveTypes.Requests.Commands;

public class UpdateLeaveTypeCommand : IRequest<Unit>
{
    public LeaveTypeDTO LeaveTypeDTO { get; set; }
}
