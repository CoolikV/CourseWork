using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IManagementService
    {
        void AddTour(TourDTO tourDTO);
        void EditTour(TourDTO tourDTO);
        void DeleteTour(int id);
        void Dispose();
    }
}
