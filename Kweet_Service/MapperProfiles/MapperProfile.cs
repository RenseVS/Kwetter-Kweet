using System;
using AutoMapper;
using Kweet_Service.DTOs;
using Kweet_Service.Entities;
using MessageContracts;

namespace Kweet_Service.MapperProfiles
{
	public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Tweet, TweetDTO>()
               .ReverseMap();
            CreateMap<Tweet, TweetMade>();
        }
    }
}

