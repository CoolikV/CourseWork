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

namespace TourAgency.Controllers// сделать окно для поиска тура
{
    public class HomeController : Controller
    {
        ITourOrderService tourOrderService;
        IDisplayService displayService;

        public HomeController(ITourOrderService _ordService,IDisplayService _display)
        {
            tourOrderService = _ordService;
            displayService = _display;
        }

        [AllowAnonymous]
        public ActionResult Index(string searchString)
        {
            IEnumerable<TourDTO> tourDtos = displayService.GetAllTours();
            if (!String.IsNullOrEmpty(searchString))
            {
                tourDtos = displayService.FindTour(searchString);
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TourDTO, TourViewModel>()).CreateMapper();
            var tours = mapper.Map<IEnumerable<TourDTO>, List<TourViewModel>>(tourDtos);

            return View(tours);
        }
       
        [AllowAnonymous]
        public ActionResult Filter(string country, string region,string type)
        {
            IQueryable<TourDTO> tours = displayService.GetAllTours().AsQueryable();
            if(!String.IsNullOrEmpty(country) && !country.Equals("Все"))
            {
                tours = tours.Where(t => t.Country == country);
            }
            if (!String.IsNullOrEmpty(region) && !region.Equals("Все"))
            {
                tours = tours.Where(t => t.Region == region);
            }
            if(!String.IsNullOrEmpty(type) && !type.Equals("Все"))
            {
                tours = tours.Where(t => t.Type == type);
            }

            ToursFilterViewModel tfvm = new ToursFilterViewModel
            {
                Tours = tours.ToList(),
                Countries = new SelectList(displayService.GetCountries()),
                Regions = new SelectList(displayService.GetRegions()),
                Type = new SelectList(new List<string>()
                {
                    "Все","Екскурсия","Горящий", "Индивидуально"
                })
            };

            return View(tfvm);
        }

        [Authorize]
        public ActionResult MakeOrder(int? id)
        {
            try
            {
                TourDTO tour = displayService.GetTour(id);
                var order = new TourOrderViewModel { TourId = tour.Id, Tour = tour, Email = System.Web.HttpContext.Current.User.Identity.Name };

                return View(order);
            }
            catch(ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult MakeOrder(TourOrderViewModel order)
        {
            try
            {
                var orderDto = new TourOrderDTO { TourId = order.TourId, Date = DateTime.Now, Email = order.Email };
                tourOrderService.MakeOrder(orderDto);
                TempData["successful"] = string.Format("Спасибо, Ваш заказ успешно обработан.");
                return RedirectToAction("Index");
            }
            catch(ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(order);
        }

        [HttpGet]
        public ActionResult Search(string name)
        {
            IEnumerable<TourDTO> searchResults = displayService.FindTour(name);
            return RedirectToAction("Index", searchResults);
        }

        protected override void Dispose(bool disposing)
        {
            tourOrderService.Dispose();
            displayService.Dispose();
            base.Dispose(disposing);
        }
        
    }
}