﻿using System;
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
    public class ManagementService : IManagementService
    {
        IUnitOfWork Database { get; set; }

        public ManagementService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddTour(TourDTO tourDTO)
        {
            Tour tour = new Tour
            {
                Name = tourDTO.Name,
                Country = tourDTO.Country,
                Region = tourDTO.Region,
                Type = tourDTO.Type,
                Date = tourDTO.Date,
                Price = tourDTO.Price
            };
            Database.Tours.Create(tour);
            Database.Save();
        }

        public void EditTour(TourDTO tourDTO)
        {
            Tour tour = Database.Tours.Get(tourDTO.Id);

            if (tour == null)
                throw new ValidationException("Запрашиваемый тур не найден в базе", "");

            tour.Country = tourDTO.Country;
            tour.Date = tourDTO.Date;
            tour.Type = tourDTO.Type;
            tour.Name = tourDTO.Name;
            tour.Price = tourDTO.Price;
            tour.Region = tourDTO.Region;

            //Database.Tours.Update(tour);
            Database.Save();
        }

        public void DeleteTour(int id)
        {
            Tour tour = Database.Tours.Get(id);

            if (tour == null)
                throw new ValidationException("Запрашиваемый тур не найден в базе", "");

            Database.Tours.Delete(id);
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}