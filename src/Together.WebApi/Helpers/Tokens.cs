using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Together.WebApi.Auth;
using Together.WebApi.Models;
using Together.WebApi.ViewModels;

namespace Together.WebApi.Helpers
{
    public class Tokens
    {
        public static async Task<JwtViewModel> GenerateJwt(ClaimsIdentity identity,
            IJwtFactory jwtFactory, 
            string username, 
            JwtIssuerOptions jwtIssuerOptions)
        {
            var response = new JwtViewModel()
            {
                Id = identity.Claims.Single(c => c.Type == "id").Value,
                Token = await jwtFactory.GenerateEncodedToken(username, identity),
                ExpiresIn = (int)jwtIssuerOptions.ValidFor.TotalSeconds
            };

            return response;
        }
    }
}
