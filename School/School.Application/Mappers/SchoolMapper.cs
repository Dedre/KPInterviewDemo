using AutoMapper;
using School.Domain.ModelsDto;
using School.Presentaion.Models;

namespace School.Application.Mappers
{
    public class SchoolMapper : Profile
    {
        public SchoolMapper() {
           CreateMap<UserDto, User>()
                        .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Name} {src.Surname}"))
                        .ForMember(dest => dest.Groups, opt => opt.Ignore());

            CreateMap<GroupDto, Group>()
                .ForMember(dest => dest.Name,opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Permissions, opt => opt.Ignore());
        }
    }
}
