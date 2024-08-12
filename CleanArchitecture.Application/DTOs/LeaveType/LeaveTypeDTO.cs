using CleanArchitecture.Application.DTOs.Common;

namespace CleanArchitecture.Application.DTOs.LeaveType;

public class LeaveTypeDTO : BaseDTO, ILeaveTypeDTO
{
    public string Name { get; set; }
    public int DefaultDays { get; set; }
}