using CleanArchitecture.Application.DTOs.LeaveType;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveTypes.Requests.Queries;

public class GetLeaveTypeDetailsRequest : IRequest<LeaveTypeDTO>
{
    public int Id { get; set; }
}
