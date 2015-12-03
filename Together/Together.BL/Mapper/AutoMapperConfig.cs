using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.BL.DTOEntities;
using Together.Domain.Entities;

namespace Together.BL.Mapper
{
	public static class AutoMapperConfig
	{
		public static void Configure()
		{
			AutoMapper.Mapper.CreateMap<User, UserDto>();
			AutoMapper.Mapper.CreateMap<UserDto, User>();

		}
	}
}
