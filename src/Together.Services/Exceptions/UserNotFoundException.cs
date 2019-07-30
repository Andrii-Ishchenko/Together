using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Services.Exceptions
{
    public class UserNotFoundException : Exception
    {
        int _userId;

        public UserNotFoundException(int userId)
        {
            _userId = userId;
        }

        public override string ToString()
        {
            return $"User not found. UserId = {_userId}";
        }
    }
}
