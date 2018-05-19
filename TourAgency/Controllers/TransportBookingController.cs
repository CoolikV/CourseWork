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
        [AllowAnonymous]
        public ActionResult Index()
        {
            var transportDtos = displayService.GetAllTransport();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TransportDTO, TransportViewModel>()).CreateMapper();
            var transport = mapper.Map<IEnumerable<TransportDTO>, List<TransportViewModel>>(transportDtos);

            return View(transport);
        }

        [Authorize]
        public ActionResult MakeOrder(int? id)
        {
            try
            {
                TransportDTO transport = displayService.GetTransport(id.Value);
                var order = new TransportOrderViewModel { TransportId = transport.Id, Email = System.Web.HttpContext.Current.User.Identity.Name, Transport = transport };
                return View(order);
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
                var orderDto = new TransportOrderDTO { TransportId = order.TransportId, Date = DateTime.Now, Email = order.Email };
                orderService.OrderTransport(orderDto);
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