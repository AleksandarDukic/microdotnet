using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
           // Source -> Target   (From db model to browser)
            CreateMap<Platform, PlatformReadDto>();

            // browser --> db model
            CreateMap<PlatformCreateDto, Platform>();
        }
    }
}