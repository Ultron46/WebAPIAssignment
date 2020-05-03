using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace HotelManagement.WebAPI.Authentication
{
    public class BasicAuthAttribute : AuthorizeAttribute
    {
        private const string _key = "WebAPIKey";
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var headerKey = actionContext.Request.Headers.Where(x => x.Key == _key).SingleOrDefault();
            if (headerKey.Key != null)
            {
                string authKey = headerKey.Value.SingleOrDefault().ToString();
                string WebAPIKey = ConfigurationManager.AppSettings[_key];
                if (!authKey.Equals(WebAPIKey))
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    return;
                }
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
                return;
            }
        }
    }
}