using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.EF
{
    public class TourAgencyContext : /*DbContext,*/ IdentityDbContext<User>
    {
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<TourBooking> TourOrders { get; set; }
        public DbSet<TransportBooking> TransportOrders { get; set; }
        public DbSet<HotelBooking> HotelOrders { get; set; }
        public DbSet<ClientProfile> ClientProfiles { get; set; }

        static TourAgencyContext()
        {
            Database.SetInitializer<TourAgencyContext>(new AgencyDbInitializer());
        }
        public TourAgencyContext(string connectionString) : base(connectionString) { }

    }

    public class AgencyDbInitializer : DropCreateDatabaseAlways<TourAgencyContext>
    {
        protected override void Seed(TourAgencyContext context)
        {
            context.Tours.Add(new Tour { Name = "Test1", Country = "США", Price = 123, Region = "L.A. California", Date = new DateTime(2018,5,12), Type = "Горящий"});
            context.Tours.Add(new Tour { Name = "Test1", Country = "Уругвай", Price = 123, Region = "Тест", Date = DateTime.Today,  Type = "Екскурсия" });
            context.Tours.Add(new Tour { Name = "Test1", Country = "Уругвай", Price = 123, Region = "Тест 2", Date = DateTime.Today,  Type = "Горящий" });
            context.Tours.Add(new Tour { Name = "Test1", Country = "США", Price = 123, Region = "Маями", Date = DateTime.Today,  Type = "Екскурсия"});

            context.Hotels.Add(new Hotel {  Name = "Name", Country = "USA", /*EntranceDate = DateTime.Today, EvictionDate = new DateTime(2018, 5, 15),*/ Stars = 5 });
            //насоздавать входных данных
            /*context.Tours.Add
            context.Hotels.Add
            context.Transport.Add*/

            context.SaveChanges();
        }
    }
}
