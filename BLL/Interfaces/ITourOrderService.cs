using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
namespace BLL.Interfaces
{
    public interface ITourOrderService
    {
        void MakeOrder(TourOrderDTO orderDTO);
        void Dispose();
    }
}
