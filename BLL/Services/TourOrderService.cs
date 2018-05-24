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

namespace BLL.Services
{
    public class TourOrderService : ITourOrderService
    {
        IUnitOfWork Database { get; set; }

        public TourOrderService(IUnitOfWork uow)
        {
            Database = uow;
        }
        //TourOrderService в конструкторе принимает объект IUnitOfWork, через который идет взаимодействие с уровнем DAL.

        public void MakeOrder(TourOrderDTO orderDTO)
        {
            Tour tour = Database.Tours.Get(orderDTO.TourId);

            if (tour == null)
                throw new ValidationException("Выбраный тур не найден", "");
            TourBooking order = new TourBooking
            {
                TourId = orderDTO.TourId,
                Date = DateTime.Now,
                Email = orderDTO.Email,
                Sum = tour.Price
            };
            Database.TourOrders.Create(order);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
