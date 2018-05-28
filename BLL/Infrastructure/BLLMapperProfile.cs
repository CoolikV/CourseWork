using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Infrastructure
{
    public class BLLMapperProfile : Profile
    {
        public BLLMapperProfile()
        {
            CreateMap<Tour, TourDTO>();
            CreateMap<Hotel, HotelDTO>();
            CreateMap<User, UserDTO>();

            CreateMap<TourBooking, TourOrderDTO>();
            CreateMap<HotelBooking, HotelOrderDTO>();
            CreateMap<TransportBooking, TransportOrderDTO>();

            CreateMap<HotelOrderDTO, HotelBooking>();
            CreateMap<TourOrderDTO, TourBooking>();
            CreateMap<TransportOrderDTO, TransportBooking>();
        }
    }
}
