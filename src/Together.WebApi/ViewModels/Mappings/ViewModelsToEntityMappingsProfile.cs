using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Together.Domain.Entities;
using Together.Services.Models;
using Together.Services.Requests;

namespace Together.WebApi.ViewModels.Mappings
{
    public class ViewModelsToEntityMappingsProfile : Profile
    {
        public ViewModelsToEntityMappingsProfile()
        {
            CreateMap<UserProfile, UserProfileModel>();

            CreateMap<RegistrationRequest, UserAccount>()
                .ForMember(ua => ua.UserName, map => map.MapFrom(vm => vm.Email));

            CreateMap<CreateRouteRequest, Route>()
                .ForMember(r => r.CreatorId,
                    o => o.MapFrom(
                        (src, dest, _, context) => context.Options.Items["userId"]
                    )
                )
                .ForMember(r => r.CreateDate,
                    o => o.MapFrom(s => DateTime.UtcNow)
                );

            CreateMap<Route, RouteModel>()
                .ForMember(r => r.CreatorFirstName, o => o.MapFrom(s => s.Creator.FirstName))
                .ForMember(r => r.CreatorLastName, o => o.MapFrom(s => s.Creator.LastName));

            CreateMap<Passenger, PassengerModel>()
                .ForMember(pvm => pvm.PassengerFirstName, o => o.MapFrom(p => p.User.FirstName))
                .ForMember(pvm => pvm.PassengerLastName, o => o.MapFrom(p => p.User.LastName));

            CreateMap<RoutePoint, RoutePointModel>();

            CreateMap<CreateRoutePointRequest, RoutePoint>()
                .ForMember(rp => rp.CreatorId,
                    o => o.MapFrom(
                        (src, dest, _, context) => context.Options.Items["userId"]
                    )
                )
                .ForMember(rp => rp.CreatedDate, o => o.MapFrom(_ => DateTime.UtcNow));


        }
    }
}
