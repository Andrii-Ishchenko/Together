using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Together.Domain.Entities;
using Together.Services.Functions;

namespace Together.WebApi.Auth
{
    public class AuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            //TODO: inject
            var auth = new Authentication(new DataAccess.TogetherDbContextFactory());
            /*
            var userExist = await auth.UserExist(context.UserName, context.Password);

            if (!userExist)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            */

            var identityUser = await auth.FindUser(context.UserName, context.Password);
            if (identityUser == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            var userAccount = identityUser as UserAccount;
            if(userAccount == null)
            {
                throw new Exception();
            }

            //var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            // identity.AddClaim(new Claim("sub", context.UserName));
            // identity.AddClaim(new Claim("role", "User"));

            //identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userAccount.Id));
            //identity.AddClaim(new Claim(ClaimTypes.Name, userAccount.UserName));

            var identity = await auth.CreateIdentityAsync(userAccount, DefaultAuthenticationTypes.ExternalBearer);
            context.Validated(identity);
        }
    }
}