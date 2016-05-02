using System.Collections.Generic;
using System.Configuration;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace eFocus.Amar2000.API.Filters
{
    public class IdentityBasicAuthenticationAttribute : BasicAuthenticationAttribute
    {
        protected override async Task<IPrincipal> AuthenticateAsync(string userName, string password, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (userName != ConfigurationManager.AppSettings["BasicAuthentication.UserName"] || password != ConfigurationManager.AppSettings["BasicAuthentication.Password"])
            {
                return null;
            }

            Claim nameClaim = new Claim(ClaimTypes.Name, userName);
            List<Claim> claims = new List<Claim> { nameClaim };

            // important to set the identity this way, otherwise IsAuthenticated will be false
            // see: http://leastprivilege.com/2012/09/24/claimsidentity-isauthenticated-and-authenticationtype-in-net-4-5/
            ClaimsIdentity identity = new ClaimsIdentity(claims, "Basic");

            var principal = new ClaimsPrincipal(identity);
            return principal;
        }
    }
}