using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Services.Exceptions
{
    public class UserNotFoundException : BusinessException
    {
        public UserNotFoundException(string userId)
            :base($"User not found. UserId = {userId}", System.Net.HttpStatusCode.NotFound)
        {
        }
    }
}
