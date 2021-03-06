﻿using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Together.BL.DTO;
using Together.Domain;

namespace Together.BL
{
    public static class AutoMapperConfig
    {

        public static void Configure()
        {          
            var cfg = new MapperConfigurationExpression();

            cfg.CreateMap<Route, ListRouteModel>()
                .ForMember(dest => dest.Passengers, s => s.MapFrom(o => o.RouteUsers.Count))
                .ForMember(dest => dest.StartPoint, s => s.MapFrom(o => o.RoutePoints.OrderBy(x=>x.ListOrder).FirstOrDefault()))
                .ForMember(dest => dest.EndPoint, s => s.MapFrom(o => o.RoutePoints.OrderBy(x => x.ListOrder).LastOrDefault()));

            cfg.CreateMap<Route, RouteModel>();

            cfg.CreateMap<AppUser, UserListModel>();

            cfg.CreateMap<RoutePoint, RoutePointListModel>();

            AutoMapper.Mapper.Initialize(cfg);
           
        }
    }
}