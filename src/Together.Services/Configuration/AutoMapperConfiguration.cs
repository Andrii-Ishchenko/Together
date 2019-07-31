using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.Domain.Entities;
using Together.Services.Models;

namespace Together.Services.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            var cfg = new MapperConfigurationExpression();

            cfg.CreateMap<Passenger, RouteListPassengerModel>()
                .ForMember(model => model.PassengerId, opt => opt.MapFrom(p => p.Id))
                .ForMember(model => model.FirstName, opt => opt.MapFrom(p => p.User.FirstName))
                .ForMember(model => model.LastName, opt => opt.MapFrom(p => p.User.LastName));

            cfg.CreateMap<Route, RouteListModel>()
               .ForMember(dest => dest.PassengersCount, opt => opt.MapFrom(r => r.Passengers.Count));

            cfg.CreateMap<Passenger, NewPassengerModel>();

            cfg.CreateMap<RoutePoint, RoutePointModel>()
                .ForMember(dest => dest.CreatorFirstName, opt => opt.MapFrom(rp => rp.Creator.FirstName))
                .ForMember(dest => dest.CreatorLastName, opt => opt.MapFrom(rp => rp.Creator.LastName));

            Mapper.Initialize(cfg);
        }
    }
}
