using CleanArchitecture.Application.DTOs.Common;

namespace CleanArchitecture.Application.DTOs;

public class LeaveTypeDTO:BaseDTO
{
    public string Name { get; set; }
    public int DefaultDays { get; set; }
}