using AutoMapper;
using CleanArchitecture.Application.Dtos.EmailConfigDtos.RequestDto;
using CleanArchitecture.Application.Dtos.EmailConfigDtos.ResponseDto;
using CleanArchitecture.Domain.Entities.EmailConfigEntities;

namespace CleanArchitecture.Application.Mapping;
public class EmailConfigProfiler : Profile
{
    public EmailConfigProfiler()
    {
        CreateMap<EmailConfig, EmailConfigRequestDto>().ReverseMap();
        CreateMap<EmailConfig, EmailConfigResponseDto>().ReverseMap();
    }
}
