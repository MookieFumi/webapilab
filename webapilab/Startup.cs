﻿using System;
using System.Configuration;
using System.Reflection;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using webapilab;
using webapilab.crosscutting;
using webapilab.entities;
using webapilab.Infrastructure;
using webapilab.Infrastructure.Providers;
using webapilab.services;
using webapilab.services.Impl;

[assembly: OwinStartup(typeof(Startup))]
namespace webapilab
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);

            var config = new HttpConfiguration();

            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);

            //Ninject
            app.UseNinjectMiddleware(CreateKernel);
            app.UseNinjectWebApi(config);

            //From Global.asax
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //http://bitoftech.net/2014/06/01/token-based-authentication-asp-net-web-api-2-owin-asp-net-identity/
        private static void ConfigureOAuth(IAppBuilder app)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            var authenticationOptions = new OAuthBearerAuthenticationOptions()
            {
                AuthenticationMode = AuthenticationMode.Active
            };
            app.UseOAuthBearerAuthentication(authenticationOptions);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<IMembersService>().To<MembersService>();
            kernel.Bind<ITownsService>().To<TownsService>();
            kernel.Bind<IAuthService>().To<AuthService>();

            kernel.Bind<AuthContext>().To<AuthContext>().InRequestScope().WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["AuthContext"].ConnectionString);

            return kernel;
        }
    }
}