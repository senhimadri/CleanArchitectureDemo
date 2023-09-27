using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.DTOs.LeaveRequest;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Profiles;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<LeaveRequest,LeaveRequestDTO>().ReverseMap();
        CreateMap<LeaveRequest,LeaveRequestListDTO>().ReverseMap();
        CreateMap<LeaveAllocation,LeaveAllocationDTO>().ReverseMap();
        CreateMap<LeaveType,LeaveTypeDTO>().ReverseMap();
    }
}
