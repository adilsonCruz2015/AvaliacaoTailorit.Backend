﻿using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AvaliacaoTailorit.Backend.Api
{
    public class Startup
    {
		public void Configuration(IAppBuilder app)
		{
			HttpConfiguration config = new HttpConfiguration();

			WebApiConfig.Register(config);
			JsonConfig.Register(config);
			IdCConfig.Register(config);

			app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
			app.UseWebApi(config);

			SwaggerConfig.Register(config);
		}
	}
}