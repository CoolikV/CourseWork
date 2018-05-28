using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using BLL.Services;
using Microsoft.AspNet.Identity;
using BLL.Interfaces;

[assembly: OwinStartup(typeof(TourAgency.App_Start.Startup))]

namespace TourAgency.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator;
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            serviceCreator = new ServiceCreator();
            return serviceCreator.CreateUserService("AgencyDatabase");
        }
    }
}
