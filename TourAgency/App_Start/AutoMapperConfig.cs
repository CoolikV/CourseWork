using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Infrastructure;
using AutoMapper;
using TourAgency.Util;
namespace TourAgency.App_Start
{
    public class AutoMapperConfig
    {
        public static void InitializeConfig()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new WebMapperProfile());
                cfg.AddProfile(new BLLMapperProfile());
            });
        }
    }
}