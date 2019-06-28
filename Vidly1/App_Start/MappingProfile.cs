using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly1.Dtos;
using Vidly1.Models;

namespace Vidly1.App_Start
{
    //public class MappingProfile
    // 20190404 This class was added after installing AutoMapper. Derived from Profile which defined in the AutoMapper Namespace ...
    public class MappingProfile : Profile
    {
        // Constructor ...
        public MappingProfile()
        {
            // 20190404 This class needs to be loaded when the application starts ... Adding it to the Global.asax file
            // 20190404 Adding mappings. When CreateMap is called it uses Reflection to scan properties and map them based on their names ...

            // Domain to Dto ...
            Mapper.CreateMap<Customer, CustomerDto>();  // Includes Source and Target objects ...
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();  // 20190501 ...
            Mapper.CreateMap<Genre, GenreDto>();  // 20190508 ...

            // Dto to Domain ... 
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MovieDto, Movie>();
        }
    }
}