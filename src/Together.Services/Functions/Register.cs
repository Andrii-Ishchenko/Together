using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DataAccess;
using Together.DataAccess.Identity;
using Together.Domain.Entities;
using Together.Services.Exceptions;
using Together.Services.Models;
using Together.Services.Requests;

namespace Together.Services.Functions
{
    public class Register : IRegister
    {
        private TogetherDbContext _context;
        private UserAccountManager _userAccountManager;
        private UserRoleManager _userRoleManager;

        public Register(TogetherDbContextFactory factory)
        {
            _context = factory.Create();
            _userAccountManager = new UserAccountManager(new UserStore<UserAccount>(_context));
            _userRoleManager = new UserRoleManager(new RoleStore<UserRole>(_context));
        }

        public async Task<NewUserModel> RegisterUserAsync(CreateUserRequest request)
        {
            //TODO: Validate request
            using (_context)
            {
                UserAccount userAccount = await _userAccountManager.FindByEmailAsync(request.Email);

                if(userAccount != null)
                {
                    throw new UserAlreadyExistException();               
                }

                userAccount = new UserAccount() { Email = request.Email, UserName = request.Email };

                var result = await _userAccountManager.CreateAsync(userAccount, request.Password);

                if (result.Errors.Any())
                {
                    //TODO: maybe refactor this somehow
                    throw new Exception(result.Errors.First());
                }

                //TODO: pull string to const/enum
                var roleResult = await _userAccountManager.AddToRoleAsync(userAccount.Id, "User");

                if (roleResult.Errors.Any())
                {
                    throw new Exception(result.Errors.First());
                }

                UserProfile user = new UserProfile() { FirstName = request.FirstName, LastName = request.LastName, Id = userAccount.Id};


                _context.UserProfiles.Add(user);
                _context.SaveChanges();

                //TODO : Automapper
                return new NewUserModel() { UserId = user.Id};
            }
        }


    }
}
