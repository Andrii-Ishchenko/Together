using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.BL.DTOEntities;
using Together.Domain.Entities;
using AutoMapper;

namespace Together.BL
{
	public static class AutoMapperConfig
	{
		public static void Configure()
		{         
			Mapper.CreateMap<User, UserDto>();
			Mapper.CreateMap<UserDto, User>();

		}
	}
}
