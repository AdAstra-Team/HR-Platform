using AutoMapper;
using AdAstra.HRPlatform.Domain.Entities;
using AdAstra.HRPlatform.Domain.Models.Users;

namespace AdAstra.HRPlatform.API.Services
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterRequest, User>()
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.UserRoles, opt => opt.Ignore())
                ;

            CreateMap<User, AuthenticateResponse>()
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.Username, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.AccessToken, opt => opt.Ignore())
                .ForMember(dst => dst.RefreshToken, opt => opt.MapFrom(src => src.RefreshToken))
                ;

            CreateMap<User, UserResponse>()
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Roles, opt => opt.MapFrom(src =>
                    src.UserRoles.Select(x => x.Role.Name).ToList()))
                ;
        }
    }
}