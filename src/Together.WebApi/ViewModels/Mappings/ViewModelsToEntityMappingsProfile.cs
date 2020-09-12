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
            CreateMap<RegistrationViewModel, UserAccount>().ForMember(ua => ua.UserName, map => map.MapFrom(vm => vm.Email));
        }
    }
}
