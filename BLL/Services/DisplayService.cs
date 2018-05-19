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

        IMapper tourDtoMapper = new MapperConfiguration(cfg => cfg.CreateMap<Tour, TourDTO>()).CreateMapper();
        IMapper hotelDtoMapper = new MapperConfiguration(cfg => cfg.CreateMap<Hotel, HotelDTO>()).CreateMapper();
        IMapper transportDtoMapper = new MapperConfiguration(cfg => cfg.CreateMap<Transport, TransportDTO>()).CreateMapper();
        public DisplayService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public TourDTO GetTour(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id тура", "");
            var tour = Database.Tours.Get(id.Value);
            if (tour == null)
                throw new ValidationException("Тур не найден", "");
            return tourDtoMapper.Map<Tour, TourDTO>(tour);
        }

        public IEnumerable<TourDTO> GetAllTours()
        {
            return tourDtoMapper.Map<IEnumerable<Tour>, List<TourDTO>>(Database.Tours.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<TourDTO> FindTour(string name)
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Tour, TourDTO>()).CreateMapper();
            return tourDtoMapper.Map<IEnumerable<Tour>, List<TourDTO>>(Database.Tours.Find(t => t.Name == name));
        }

        public List<string> GetCountries()
        {
            List<string> result = new List<string>() {"Все"};
            var tours = GetAllTours();
            foreach(TourDTO tour in tours)
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
            if(id == null)
            {
                throw new ValidationException("Не установлено id отеля", "");
            }
            var hotel = Database.Hotels.Get(id.Value);
            if(hotel == null)
            {
                throw new ValidationException("Тур не найден", "");
            }
            return hotelDtoMapper.Map<Hotel, HotelDTO>(hotel);
        }

        public IEnumerable<HotelDTO> GetAllHotels()
        {
            return hotelDtoMapper.Map<IEnumerable<Hotel>, List<HotelDTO>>(Database.Hotels.GetAll());
        }

        public TransportDTO GetTransport(int? id)
        {
            if(id == null)
            {
                throw new ValidationException("Не установлено id транспорта", "");
            }
            var transport = Database.Transport.Get(id.Value);
            if(transport == null)
            {
                throw new ValidationException("Транспорт не найден","");
            }
            return transportDtoMapper.Map<Transport, TransportDTO>(transport);
        }

        public IEnumerable<TransportDTO> GetAllTransport()
        {
            return transportDtoMapper.Map<IEnumerable<Transport>, List<TransportDTO>>(Database.Transport.GetAll());
        }
    }
}
