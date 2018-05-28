using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TourAgency.Models;
using BLL.DTO;

namespace TourAgency.Util
{
    public class WebMapperProfile : Profile
    {
        public WebMapperProfile()
        {
            CreateMap<TourViewModel, TourDTO>();
            CreateMap<HotelViewModel, HotelDTO>();
            CreateMap<TourOrderViewModel, TourOrderDTO>();

            CreateMap<HotelOrderViewModel, HotelOrderDTO>();

            CreateMap<TransportOrderViewModel, TransportOrderDTO>();
            CreateMap<HotelDTO, HotelViewModel>();
            CreateMap<TourDTO, TourViewModel>();

        }
    }
}