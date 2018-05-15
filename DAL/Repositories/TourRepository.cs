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
    public class TourRepository : IRepository<Tour>
    {
        private TourAgencyContext db;
        public TourRepository(TourAgencyContext context)
        {
            this.db = context;
        }

        public IEnumerable<Tour> GetAll()
        {
            return db.Tours;
        }
        public Tour Get(int id)
        {
            return db.Tours.Find(id);
        }
        public void Create(Tour tour)
        {
            db.Tours.Add(tour);
        }
        public void Update(Tour tour)
        {
            db.Entry(tour).State = EntityState.Modified;
        }
        public IEnumerable<Tour> Find(Func<Tour,Boolean> predicate)
        {
            return db.Tours.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Tour tour = db.Tours.Find(id);
            if (tour != null)
            {
                db.Tours.Remove(tour);
            }
        }
    }
}
