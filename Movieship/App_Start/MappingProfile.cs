using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Movieship.DTOs;
using Movieship.Models;

namespace Movieship.App_Start
{
    public class MappingProfile : Profile
    {
       public MappingProfile()
        {
            // domain to dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<MemberShip, MemberShipDto>();
            Mapper.CreateMap<Movies, MoviesDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            //dto to domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c=>c.Id, opt=>opt.Ignore());

            Mapper.CreateMap<MoviesDto, Movies>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}