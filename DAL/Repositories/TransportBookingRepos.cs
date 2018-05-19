using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    class TransportBookingRepos : IRepository<TransportBooking>
    {
        private TourAgencyContext db;
        public TransportBookingRepos(TourAgencyContext context)
        {
            this.db = context;
        }

        public IEnumerable<TransportBooking> GetAll()
        {
            return db.TransportOrders;
        }
        public TransportBooking Get(int id)
        {
            return db.TransportOrders.Find(id);
        }
        public void Create(TransportBooking transportB)
        {
            db.TransportOrders.Add(transportB);
        }
        public void Update(TransportBooking transportB)
        {
            db.Entry(transportB).State = EntityState.Modified;
        }
        public IEnumerable<TransportBooking> Find(Func<TransportBooking, Boolean> predicate)
        {
            return db.TransportOrders.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            TransportBooking transportB = db.TransportOrders.Find(id);
            if (transportB != null)
            {
                db.TransportOrders.Remove(transportB);
            }
        }
    }
}
