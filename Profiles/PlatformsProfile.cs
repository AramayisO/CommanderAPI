using AutoMapper;
using CommanderAPI.Dtos;
using CommanderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderAPI.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<PlatformCreateDto, Platform>();
            CreateMap<PlatformUpdateDto, Platform>();
            CreateMap<Platform, PlatformUpdateDto>();
        }
    }
}
