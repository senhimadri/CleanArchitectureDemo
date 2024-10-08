﻿using CleanArchitecture.Application.DTOs.Common;

namespace CleanArchitecture.Application.DTOs.LeaveRequest;

public class CreateLeaveRequestDTO : IleaveRequestDTO
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int LeaveTypeId { get; set; }
    public string RequestComments { get; set; }
}
