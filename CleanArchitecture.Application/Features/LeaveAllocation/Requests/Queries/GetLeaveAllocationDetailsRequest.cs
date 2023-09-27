using CleanArchitecture.Application.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveAllocation.Requests.Queries;

public class GetLeaveRequestDetailsRequest : IRequest<LeaveAllocationDTO>
{
    public int Id { get; set; }
}
