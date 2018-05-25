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
    public class DisplayService : IDisplayService
    {
        IUnitOfWork Database { get; set; }

        public DisplayService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public TourDTO GetTour(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id тура", "");
            var tour = Database.Tours.GetByID(id.Value);
            if (tour == null)
                throw new ValidationException("Тур не найден", "");
            return Mapper.Map<Tour, TourDTO>(tour);
        }

        public IEnumerable<TourDTO> GetAllTours()
        {
            return Mapper.Map<IEnumerable<Tour>, List<TourDTO>>(Database.Tours.Get());
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<TourDTO> FindTour(string name)
        {
            return Mapper.Map<IEnumerable<Tour>, List<TourDTO>>(Database.Tours.Get(t => t.Name == name));
        }

        public List<string> GetCountries()
        {
            List<string> result = new List<string>() { "Все" };
            var tours = GetAllTours();
            foreach (TourDTO tour in tours)
            {
                if (!result.Contains(tour.Country))
                {
                    result.Add(tour.Country);
                }
            }
            return result;
        }

        public List<string> GetRegions()
        {
            List<string> result = new List<string>() { "Все" };
            var tours = GetAllTours();
            foreach (TourDTO tour in tours)
            {
                if (!result.Contains(tour.Region))
                {
                    result.Add(tour.Region);
                }
            }
            return result;
        }


        public HotelDTO GetHotel(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id отеля", "");
            }
            var hotel = Database.Hotels.GetByID(id.Value);
            if (hotel == null)
            {
                throw new ValidationException("Тур не найден", "");
            }
            return Mapper.Map<Hotel, HotelDTO>(hotel);
        }

        public IEnumerable<HotelDTO> GetAllHotels()
        {
            return Mapper.Map<IEnumerable<Hotel>, List<HotelDTO>>(Database.Hotels.Get());
        }

        public TransportDTO GetTransport(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id транспорта", "");
            }
            var transport = Database.Transport.GetByID(id.Value);
            if (transport == null)
            {
                throw new ValidationException("Транспорт не найден", "");
            }
            return Mapper.Map<Transport, TransportDTO>(transport);
        }

        public IEnumerable<TransportDTO> GetAllTransport()
        {
            return Mapper.Map<IEnumerable<Transport>, List<TransportDTO>>(Database.Transport.Get());
        }
    }
}
