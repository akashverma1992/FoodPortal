﻿using System.Net.Http.Headers;
using System.Web.Http;

namespace FoodPortal_WebApi {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) { 
            // Web API configuration and services
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters
                .JsonFormatter
                .SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("application/json"));
        }
    }
}
