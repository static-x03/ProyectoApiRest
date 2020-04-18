using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Proyecto.Api.Rest
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Remueve el Resultado En XML y solo se Visualiza en Json
			var json = config.Formatters.JsonFormatter;
			json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
			config.Formatters.Remove(config.Formatters.XmlFormatter);
			//


			// Rutas de API web
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
