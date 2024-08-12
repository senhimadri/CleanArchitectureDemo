using MediatR;

namespace CleanArchitecture.Application.Features.LeaveTypes.Requests.Commands;

public class DeleteLeaveTypeCommand : IRequest
{
    public int id { get; set; }
}
