using Together.DAL.Infrastructure.Abstract;
using Together.Domain.Entities;

namespace Together.BL.Services.Concrete
{
    public class UserService :BaseService<User>
    {
        public UserService(IUnitOfWorkFactory factory)
            :base(factory)
        {

        }
    }
}
