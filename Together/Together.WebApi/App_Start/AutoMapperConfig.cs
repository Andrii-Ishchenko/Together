﻿using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Together.Domain.Entities;
using Together.WebApi.Models;

namespace Together.WebApi
{
    public static class AutoMapperConfig
    {

        public static void Configure()
        {          
            var cfg = new MapperConfigurationExpression();

            cfg.CreateMap<Route, ListRouteModel>()
                .ForMember(dest => dest.Passengers, s => s.MapFrom(o => o.RouteUsers.Count))
                .ForMember(dest => dest.StartPoint, s => s.MapFrom(o => o.RoutePoints.FirstOrDefault()))
                .ForMember(dest => dest.EndPoint, s => s.MapFrom(o => o.RoutePoints.LastOrDefault()));

            cfg.CreateMap<User, UserListModel>();

            cfg.CreateMap<RoutePoint, RoutePointListModel>();

            AutoMapper.Mapper.Initialize(cfg);
           
        }
    }
}