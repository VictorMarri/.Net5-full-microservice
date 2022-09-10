using AutoMapper;
using PlatformService.API.DTOs;
using PlatformService.API.Models;

namespace PlatformService.API.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            // Source ---> Target (Post)
            CreateMap<Platform, PlatformReadDTO>();

            // (GET)
            CreateMap<PlatformCreateDTO, Platform>();
        }
    }
}
