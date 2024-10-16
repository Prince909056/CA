using AutoMapper;
using CleanArchitecture.Application.Dtos.UserDtos.RequestDto;
using CleanArchitecture.Application.Dtos.UserDtos.ResponseDto;
using CleanArchitecture.Domain.Entities.Users;

namespace CleanArchitecture.Application.Mapping;
public class UserProfiler : Profile
{
    public UserProfiler()
    {
        CreateMap<User, UserRequestDto>().ReverseMap();
        CreateMap<User, UserResponseDto>().ReverseMap();
    }
}
