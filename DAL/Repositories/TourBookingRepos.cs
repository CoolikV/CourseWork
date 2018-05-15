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
    class TourBookingRepos : IRepository<TourBooking>
    {
        private TourAgencyContext db;
        public TourBookingRepos(TourAgencyContext context)
        {
            this.db = context;
        }

        public IEnumerable<TourBooking> GetAll()
        {
            return db.TourOrders;
        }
        public TourBooking Get(int id)
        {
            return db.TourOrders.Find(id);
        }
        public void Create(TourBooking tourB)
        {
            db.TourOrders.Add(tourB);
        }
        public void Update(TourBooking tourB)
        {
            db.Entry(tourB).State = EntityState.Modified;
        }
        public IEnumerable<TourBooking> Find(Func<TourBooking, Boolean> predicate)
        {
            return db.TourOrders.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            TourBooking tourB = db.TourOrders.Find(id);
            if (tourB != null)
            {
                db.TourOrders.Remove(tourB);
            }
        }
    }
}
