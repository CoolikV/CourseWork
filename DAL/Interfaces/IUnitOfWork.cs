using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Identity;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        UserManager UserManager { get; }
        IClientManager ClientManager { get; }
        UserRoleManager RoleManager { get; }
        Task SaveAsync();

        IRepository<Tour> Tours { get; }
        IRepository<Hotel> Hotels { get; }
        IRepository<TourBooking> TourOrders { get; }
        IRepository<HotelBooking> HotelOrders { get; }
        IRepository<TransportBooking> TransportOrders { get; }
        void Save();

    }
}
