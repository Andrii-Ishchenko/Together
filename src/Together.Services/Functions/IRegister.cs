using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.Services.Models;
using Together.Services.Requests;

namespace Together.Services.Functions
{
    public interface IRegister
    {
        Task<NewUserModel> RegisterUserAsync(CreateUserRequest request);
    }
}
