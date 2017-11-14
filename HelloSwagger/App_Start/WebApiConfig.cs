using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Swashbuckle.SwaggerUi;

namespace HelloSwagger
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //name: "help_ui_shortcut",
            //routeTemplate: "help",
            //defaults: null,
            //constraints: null,
            //handler: new RedirectHandler(SwaggerDocsConfig.DefaultRootUrlResolver, "documentation/index"));

            //config.Services.Replace(typeof(IHttpControllerSelector), new ControllerSelector(config));
            
            //config.EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API")).EnableSwaggerUi();
        }
    }
}
