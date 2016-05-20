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
        protected override Task<IPrincipal> AuthenticateAsync(string userName, string password, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (userName != ConfigurationManager.AppSettings["BasicAuthentication.UserName"] || password != ConfigurationManager.AppSettings["BasicAuthentication.Password"])
            {
                return null;
            }

            var nameClaim = new Claim(ClaimTypes.Name, userName);
            var claims = new List<Claim> { nameClaim };

            // important to set the identity this way, otherwise IsAuthenticated will be false
            // see: http://leastprivilege.com/2012/09/24/claimsidentity-isauthenticated-and-authenticationtype-in-net-4-5/
            var identity = new ClaimsIdentity(claims, "Basic");

            var principal = new ClaimsPrincipal(identity);
            return Task.Factory.StartNew(() => (IPrincipal)principal, cancellationToken);
        }
    }
}