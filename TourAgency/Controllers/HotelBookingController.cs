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

            var hotels = Mapper.Map<IEnumerable<HotelDTO>, List<HotelViewModel>>(hotelDtos);

            return View(hotels);
        }

        [Authorize]
        public ActionResult MakeOrder(int? id)
        {
            try
            {
                HotelDTO hotel = displayService.GetHotel(id.Value);
                var order = new HotelOrderViewModel
                {
                    HotelId = hotel.Id,
                    Email = System.Web.HttpContext.Current.User.Identity.Name,
                    Hotel = hotel,
                };

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
                var orderDto = Mapper.Map<HotelOrderDTO>(order);
                orderDto.Date = DateTime.Now;
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