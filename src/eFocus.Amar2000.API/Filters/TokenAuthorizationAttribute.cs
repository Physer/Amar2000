using System.Configuration;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace eFocus.Amar2000.API.Filters
{
    public class TokenAuthorizationAttribute : AuthorizeAttribute
    {
        public string AuthToken { get; set; }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var authorizationHeader = actionContext.Request.Headers.Authorization;
            if (authorizationHeader?.Scheme != "Bearer") return false;
            var authToken = string.IsNullOrWhiteSpace(AuthToken)  ? ConfigurationManager.AppSettings["AuthToken"] : AuthToken;
            return authorizationHeader.Parameter == authToken;
        }
    }
}
