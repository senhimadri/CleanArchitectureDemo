using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveAllocation;
using CleanArchitecture.Application.DTOs.LeaveRequest;
using CleanArchitecture.Application.DTOs.LeaveType;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        CreateMap<LeaveRequest, LeaveRequestDTO>().ReverseMap();
        CreateMap<LeaveRequest, LeaveRequestListDTO>()
            .ForMember(dest => dest.DateRequested, opt => opt.MapFrom(src => src.DateCreated))
            .ReverseMap();
        CreateMap<LeaveRequest, CreateLeaveRequestDTO>().ReverseMap();
        CreateMap<LeaveRequest, UpdateLeaveRequestDTO>().ReverseMap();


        CreateMap<LeaveAllocation, LeaveAllocationDTO>().ReverseMap();
        CreateMap<LeaveAllocation, CreateLeaveAllocationDTO>().ReverseMap();
        CreateMap<LeaveAllocation, UpdateLeaveAllocationDTO>().ReverseMap();

        CreateMap<LeaveType, LeaveTypeDTO>().ReverseMap();
        CreateMap<LeaveType, CreateLeaveTypeDTO>().ReverseMap();
    }
}
