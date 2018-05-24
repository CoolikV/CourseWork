using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IOtherOrderService
    {
        void OrderHotel(HotelOrderDTO hotelDTO);
        void OrderTransport(TransportOrderDTO transportDTO);
        void Dispose();
    }
}
