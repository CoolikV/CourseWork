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
    class TransportRepository : IRepository<Transport>
    {
        private TourAgencyContext db;
        public TransportRepository(TourAgencyContext context)
        {
            this.db = context;
        }

        public IEnumerable<Transport> GetAll()
        {
            return db.Transport;
        }
        public Transport Get(int id)
        {
            return db.Transport.Find(id);
        }
        public void Create(Transport transport)
        {
            db.Transport.Add(transport);
        }
        public void Update(Transport transport)
        {
            db.Entry(transport).State = EntityState.Modified;
        }
        public IEnumerable<Transport> Find(Func<Transport, Boolean> predicate)
        {
            return db.Transport.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Transport transport = db.Transport.Find(id);
            if (transport != null)
            {
                db.Transport.Remove(transport);
            }
        }
    }
}

