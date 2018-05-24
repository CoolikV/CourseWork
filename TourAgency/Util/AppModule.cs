using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;

namespace TourAgency.Util
{
    public class AppModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITourOrderService>().To<TourOrderService>();//интерфейс ITourOrderService сопоставляется с классом TourOrderService i td...
            Bind<IOtherOrderService>().To<OtherOrderService>();
            Bind<IDisplayService>().To<DisplayService>();
            Bind<IManagementService>().To<ManagementService>();
        }
    }
}