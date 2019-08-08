using AutoMapper;
using MovieBackLogFramework.DTOS;
using MovieBackLogFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieBackLogFramework.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Dto to domain
            CreateMap<MovieDto, Movie>();

            // Domain to dto
            CreateMap<Movie, MovieDto>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            
            
        }
       
    }
}