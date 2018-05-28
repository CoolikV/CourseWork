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
    [Authorize(Roles ="manager")]
    public class ManagerController : Controller
    {
        IManagementService managementService;
        IDisplayService displayService;
        public ManagerController(IDisplayService display,IManagementService management)
        {
            managementService = management;
            displayService = display;
        }
        public ActionResult Index()
        {
            IEnumerable<TourDTO> tourDtos = displayService.GetAllTours();

            return View(Mapper.Map<IEnumerable<TourDTO>, List<TourViewModel>>(tourDtos));
        }

        public ActionResult EditTour(int? id)
        {
            try
            {
                TourDTO tour = displayService.GetTour(id);

                return View(Mapper.Map<TourDTO, TourViewModel>(tour));
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult EditTour(TourViewModel tour,string type)
        {
            try
            {
                if (ModelState.IsValid)
                {                   
                    managementService.EditTour(Mapper.Map<TourDTO>(tour));

                    TempData["successful"] = string.Format("Изменения в туре \"{0}\" были сохранены", tour.Name);
                    return RedirectToAction("Index", "Manager");
                }
                return View(tour);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(tour);
        }

        public ActionResult CreateTour()
        {
            return View(new TourViewModel());
        }
        [HttpPost]
        public ActionResult CreateTour(TourViewModel newTour)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var tourDto = Mapper.Map<TourDTO>(newTour);
                    managementService.AddTour(tourDto);
                    TempData["successful"] = string.Format("Новый тур \"{0}\" был добавлен", newTour.Name);
                    return RedirectToAction("Index", "Manager");
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);

            }
            return View(newTour);
        }
        [HttpPost]
        public ActionResult DeleteTour(int id)
        {
            try
            {
                TourDTO tour = displayService.GetTour(id);
                if(tour != null)
                {
                    managementService.DeleteTour(id);
                    TempData["successful"] = string.Format("Тур \"{0}\" был удален",tour.Name);
                }
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
    }
}