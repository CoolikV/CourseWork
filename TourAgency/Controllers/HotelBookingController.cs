using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using AutoMapper;
using TourAgency.Models;

namespace TourAgency.Controllers
{
    public class HotelBookingController : Controller
    {
        IDisplayService displayService;
        IOtherOrderService orderService;

        public HotelBookingController(IOtherOrderService _orderService, IDisplayService _displayService)
        {
            displayService = _displayService;
            orderService = _orderService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var hotelDtos = displayService.GetAllHotels();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HotelDTO, HotelViewModel>()).CreateMapper();
            var hotels = mapper.Map<IEnumerable<HotelDTO>, List<HotelViewModel>>(hotelDtos);

            return View(hotels);
        }

        [Authorize]
        public ActionResult MakeOrder(int? id)
        {
            try
            {
                HotelDTO hotel = displayService.GetHotel(id.Value);
                var order = new HotelOrderViewModel { HotelId = hotel.Id, Email = System.Web.HttpContext.Current.User.Identity.Name, Hotel = hotel };

                return View(order);
            }
            catch( ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult MakeOrder(HotelOrderViewModel order)
        {
            try
            {
                var orderDto = new HotelOrderDTO { HotelId = order.HotelId, Date = DateTime.Now, Email = order.Email, EntranceDate = order.EntranceDate, EvictionDate = order.EvictionDate };
                orderService.OrderHotel(orderDto);
                TempData["successful"] = string.Format("Спасибо, Ваш заказ успешно обработан.");
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
    }
}