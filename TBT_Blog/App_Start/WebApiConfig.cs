using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace TBT_Blog
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var jsonSerializerSetting = config.Formatters.JsonFormatter.SerializerSettings;
           // jsonSerializerSetting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSerializerSetting.Formatting = Newtonsoft.Json.Formatting.Indented;
            jsonSerializerSetting.DateFormatString = "dd/MM/yyyy";

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "Posts", id = RouteParameter.Optional }
            );
        }
    }
}
