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
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization != null)
            {
                var key = actionContext.Request.Headers
                    .Authorization.Parameter.ToString();
                string WebAPIKey = ConfigurationManager.AppSettings["WebAPIKey"];
                if (!key.Equals(WebAPIKey))
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
    }
}