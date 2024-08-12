using MediatR;

namespace CleanArchitecture.Application.Features.LeaveAllocation.Requests.Commands;

public class DeleteLeaveAllocationCommand : IRequest
{
    public int Id { get; set; }
}
