﻿using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveAllocation;
using CleanArchitecture.Application.DTOs.LeaveRequest;
using CleanArchitecture.Application.DTOs.LeaveType;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Profiles;

public class MappingProfile: Profile
{
    public MappingProfile()
    {


        CreateMap<LeaveRequest,LeaveRequestDTO>().ReverseMap();
        CreateMap<LeaveRequest,LeaveRequestListDTO>().ReverseMap();
        CreateMap<LeaveRequest,CreateLeaveRequestDTO>().ReverseMap();

        CreateMap<LeaveAllocation,LeaveAllocationDTO>().ReverseMap();

        CreateMap<LeaveType,LeaveTypeDTO>().ReverseMap();
    }
}
