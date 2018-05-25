using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Infrastructure;
using BLL.DTO;
using DAL.Entities;
using DAL.Interfaces;
using AutoMapper;
using BLL.BusinessModels;

namespace BLL.Services
{
    public class OtherOrderService : IOtherOrderService
    {
        IUnitOfWork Database { get; set; }

        public OtherOrderService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void OrderHotel(HotelOrderDTO orderDTO)
        {
            Hotel hotel = Database.Hotels.GetByID(orderDTO.HotelId);
            if (hotel == null)
                throw new ValidationException("Отель не найден", "");
            HotelBooking hotelBooking = Mapper.Map<HotelOrderDTO, HotelBooking>(orderDTO);
            hotelBooking.Sum = new Price(hotel.Stars, orderDTO.EvictionDate, orderDTO.EntranceDate).CalculatePrice();

            Database.HotelOrders.Insert(hotelBooking);
            Database.Save();
        }

        public void OrderTransport(TransportOrderDTO orderDTO)
        {
            Transport transport = Database.Transport.GetByID(orderDTO.TransportId);

            if (transport == null)
                throw new ValidationException("Транспорт не найден", "");

            TransportBooking order = new TransportBooking
            {
                Date = DateTime.Now,
                Email = orderDTO.Email,
                Sum = transport.Price,
                TransportId = orderDTO.TransportId
            };
            Database.TransportOrders.Insert(order);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
