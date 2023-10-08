using CleanArchitecture.Application.DTOs.Common;

namespace CleanArchitecture.Application.DTOs.LeaveAllocation;

public class UpdateLeaveAllocationDTO: BaseDTO, ILeaveAllocationDTO
{
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}
