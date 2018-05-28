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
    public class TransportBookingController : Controller
    {
        IDisplayService displayService;
        IOtherOrderService orderService;

        public TransportBookingController(IOtherOrderService _orderService, IDisplayService _displayService)
        {
            displayService = _displayService;
            orderService = _orderService;
        }

        [Authorize]
        public ActionResult MakeOrder()
        {
            try
            {
                return View(new TransportOrderViewModel());
            }
            catch(ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult MakeOrder(TransportOrderViewModel order)
        {
            try
            {
                var orderDto = new TransportOrderDTO {
                    TransportType = (int)order.TransportType,
                    DepartureDate = order.DepartureDate,
                    Email = System.Web.HttpContext.Current.User.Identity.Name
                };

                orderService.OrderTransport(orderDto);
                TempData["successful"] = string.Format("Спасибо, Ваш заказ успешно обработан.");
                return RedirectToAction("Index", "Home");
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
    }
}