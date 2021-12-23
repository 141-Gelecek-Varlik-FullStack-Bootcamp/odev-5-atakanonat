using System;
using AutoMapper;
using Comm.DB.Entities;
using Comm.Model.User;

namespace Comm.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, Person>()
                .ForMember(m => m.Udate, um => um.MapFrom(src => DateTime.Now));
            CreateMap<Person, User>();

            CreateMap<Model.Product.Product, DB.Entities.Product>()
                .ForMember(m => m.Udate, um => um.MapFrom(src => DateTime.Now));
            CreateMap<DB.Entities.Product, Model.Product.Product>();
        }
    }
}