using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Services.Exceptions
{
    public class UserNotFoundException : Exception
    {
        string _userId;

        public UserNotFoundException(string userId)
        {
            _userId = userId;
        }

        public override string ToString()
        {
            return $"User not found. UserId = {_userId}";
        }
    }
}
