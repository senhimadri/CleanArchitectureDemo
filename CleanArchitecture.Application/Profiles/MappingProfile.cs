using AutoMapper;
using CleanArchitecture.Application.DTOs;
using ClieaArchitecture.Domain;

namespace CleanArchitecture.Application.Profiles;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<LeaveRequest,LeaveRequestDTO>().ReverseMap();
    }
}
