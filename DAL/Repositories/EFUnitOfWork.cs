using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private TourAgencyContext db;

        private GenericRepository<Tour> tourRepository;
        private GenericRepository<Hotel> hotelRepository;
        private GenericRepository<Transport> transportRepository;
        private GenericRepository<TourBooking> tourBookingRepos;
        private GenericRepository<HotelBooking> hotelBookingRepos;
        private GenericRepository<TransportBooking> transportBookingRepos;

        private UserManager userManager;
        private UserRoleManager roleManager;
        private IClientManager clientManager;

        public EFUnitOfWork(string connectionString)
        {
            db = new TourAgencyContext(connectionString);

            userManager = new UserManager(new UserStore<User>(db));
            roleManager = new UserRoleManager(new RoleStore<UserRole>(db));
            clientManager = new ClientManager(db);
        }
        public IRepository<Tour> Tours
        {
            get
            {
                if (tourRepository == null)
                    tourRepository = new GenericRepository<Tour>(db);
                return tourRepository;
            }
        }

        public IRepository<Hotel> Hotels
        {
            get
            {
                if (hotelRepository == null)
                    hotelRepository = new GenericRepository<Hotel>(db);
                return hotelRepository;
            }
        }

        public IRepository<Transport> Transport
        {
            get
            {
                if (transportRepository == null)
                    transportRepository = new GenericRepository<Transport>(db);
                return transportRepository;
            }
        }

        public IRepository<TourBooking> TourOrders
        {
            get
            {
                if (tourBookingRepos == null)
                    tourBookingRepos = new GenericRepository<TourBooking>(db);
                return tourBookingRepos;
            }
        }

        public IRepository<HotelBooking> HotelOrders
        {
            get
            {
                if (hotelBookingRepos == null)
                    hotelBookingRepos = new GenericRepository<HotelBooking>(db);
                return hotelBookingRepos;
            }
        }

        public IRepository<TransportBooking> TransportOrders
        {
            get
            {
                if (transportBookingRepos == null)
                    transportBookingRepos = new GenericRepository<TransportBooking>(db);
                return transportBookingRepos;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public UserManager UserManager
        {
            get { return userManager; }
        }

        public IClientManager ClientManager
        {
            get { return clientManager; }
        }

        public UserRoleManager RoleManager
        {
            get { return roleManager; }
        }
    }
}
