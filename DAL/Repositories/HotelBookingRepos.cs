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
    class HotelBookingRepos : IRepository<HotelBooking>
    {
        private TourAgencyContext db;
        public HotelBookingRepos(TourAgencyContext context)
        {
            this.db = context;
        }

        public IEnumerable<HotelBooking> GetAll()
        {
            return db.HotelOrders;
        }
        public HotelBooking Get(int id)
        {
            return db.HotelOrders.Find(id);
        }
        public void Create(HotelBooking hotelB)
        {
            db.HotelOrders.Add(hotelB);
        }
        public void Update(HotelBooking hotelB)
        {
            db.Entry(hotelB).State = EntityState.Modified;
        }
        public IEnumerable<HotelBooking> Find(Func<HotelBooking, Boolean> predicate)
        {
            return db.HotelOrders.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            HotelBooking hotelB = db.HotelOrders.Find(id);
            if (hotelB != null)
            {
                db.HotelOrders.Remove(hotelB);
            }
        }
    }
}
