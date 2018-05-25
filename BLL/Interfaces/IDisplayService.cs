using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IDisplayService
    {
        TourDTO GetTour(int? id);
        IEnumerable<TourDTO> GetAllTours();
        List<string> GetCountries();
        List<string> GetRegions();
        IEnumerable<TourDTO> FindTour(string name);

        HotelDTO GetHotel(int? id);
        IEnumerable<HotelDTO> GetAllHotels();

        void Dispose();
    }
}
