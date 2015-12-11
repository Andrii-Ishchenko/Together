using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.BL.DTOEntities;
using Together.BL.Services.Abstract;

namespace Together.BL.Services.Concrete
{
    public class UserService<TEntityDto> :BaseService<TEntityDto,UserDto>,IUserService
        where TEntityDto: class
    {

    }
}
