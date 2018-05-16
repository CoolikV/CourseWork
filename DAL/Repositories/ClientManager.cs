using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class ClientManager : IClientManager
    {
        public TourAgencyContext Database { get; set; }
        public ClientManager(TourAgencyContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile profile)
        {
            Database.ClientProfiles.Add(profile);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
