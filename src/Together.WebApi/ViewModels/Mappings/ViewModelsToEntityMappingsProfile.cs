using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Together.Domain.Entities;

namespace Together.WebApi.ViewModels.Mappings
{
    public class ViewModelsToEntityMappingsProfile : Profile
    {
        public ViewModelsToEntityMappingsProfile()
        {
            CreateMap<UserProfile, UserProfileViewModel>();
            CreateMap<RegistrationViewModel, UserAccount>().ForMember(ua => ua.UserName, map => map.MapFrom(vm => vm.Email));
            CreateMap<CreateRouteViewModel, Route>()
                .ForMember(r => r.CreatorId,
                    o => o.MapFrom(
                        (src, dest, _, context) => context.Options.Items["userId"]
                    )
                )
                .ForMember(r => r.CreateDate,
                    o => o.MapFrom(s => DateTime.UtcNow)
                );

            CreateMap<Route, RouteViewModel>()
                .ForMember(r => r.CreatorFirstName, o => o.MapFrom(s => s.Creator.FirstName))
                .ForMember(r => r.CreatorLastName, o => o.MapFrom(s => s.Creator.LastName));

            CreateMap<Passenger, PassengerViewModel>()
                .ForMember(pvm => pvm.PassengerFirstName, o => o.MapFrom(p => p.User.FirstName))
                .ForMember(pvm => pvm.PassengerLastName, o => o.MapFrom(p => p.User.LastName));

            CreateMap<RoutePoint, RoutePointViewModel>();
        }
    }
}
