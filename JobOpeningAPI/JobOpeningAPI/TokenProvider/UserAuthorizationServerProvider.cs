using JobOpeningAPI.Repositories;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace JobOpeningAPI.TokenProvider
{
    public class UserAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using(UserValidateRepository userValidateRepository = new UserValidateRepository())
            {
                var user = userValidateRepository.ValidateUser(context.UserName, context.Password);
                if(user == null)
                {
                    context.SetError("invalid_grant", "UserName or Password is incorrect!!");
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                if(user != null)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                    context.Validated(identity);
                }
                
            }
        }
    }
}