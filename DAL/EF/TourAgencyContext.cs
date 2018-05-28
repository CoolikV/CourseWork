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
          //  context.Tours.Add(new Tour { Name = "Test1", Country = "США", Price = 123, Region = "L.A. California", Date = new DateTime(2018,5,12), Type = "Горящий"});
          //  context.Tours.Add(new Tour { Name = "Test1", Country = "Уругвай", Price = 123, Region = "Тест", Date = DateTime.Today,  Type = "Екскурсия" });
          //  context.Tours.Add(new Tour { Name = "Test", Country = "Уругвай", Price = 123, Region = "Тест 2", Date = DateTime.Today,  Type = "Горящий" });
          //  context.Tours.Add(new Tour { Name = "What", Country = "США", Price = 123, Region = "Маями", Date = DateTime.Today,  Type = "Екскурсия"});
            context.Tours.Add(new Tour { Name = "Тур1", Country = "Индонезия", Price = 26000, Region = "Бали", Date = DateTime.Today, Type = "Индивидуально" });
            context.Tours.Add(new Tour { Name = "Тур2", Country = "Египет", Price = 6000, Region = "Хургада", Date = DateTime.Today, Type = "Екскурсия" });
            context.Tours.Add(new Tour { Name = "Тур3", Country = "Египет", Price = 8300, Region = "Шарм Эль Шейх", Date = DateTime.Today, Type = "Екскурсия" });
            context.Tours.Add(new Tour { Name = "Тур4", Country = "Испания", Price = 9900, Region = "Коста Брава", Date = DateTime.Today, Type = "Екскурсия" });
            context.Tours.Add(new Tour { Name = "Тур5", Country = "Испания", Price = 11000, Region = "Коста Дорада", Date = DateTime.Today, Type = "Индивидуально" });
            context.Tours.Add(new Tour { Name = "Тур6", Country = "Италия", Price = 19400, Region = "Рим", Date = DateTime.Today, Type = "Екскурсия" });
            context.Tours.Add(new Tour { Name = "Тур7", Country = "Италия", Price = 16100, Region = "Венеция", Date = DateTime.Today, Type = "Индивидуально" });
            context.Tours.Add(new Tour { Name = "Тур8", Country = "Турция", Price = 7000, Region = "Алания", Date = DateTime.Today, Type = "Горящий" });
            context.Tours.Add(new Tour { Name = "Тур9", Country = "Турция", Price = 4800, Region = "Кемер", Date = DateTime.Today, Type = "Индивидуально" });
            context.Tours.Add(new Tour { Name = "Тур10", Country = "Иордания", Price = 19300, Region = "Амман", Date = DateTime.Today, Type = "Горящий" });
            context.Tours.Add(new Tour { Name = "Тур11", Country = "Таиланд", Price = 24900, Region = "Пхукет", Date = DateTime.Today, Type = "Екскурсия" });
            context.Tours.Add(new Tour { Name = "Тур12", Country = "Таиланд", Price = 26200, Region = "Паттайя", Date = DateTime.Today, Type = "Горящий" });

            context.Hotels.Add(new Hotel { Name = "Modus Pattaya Resort", Country = "Таиланд", Stars = 5 });
            context.Hotels.Add(new Hotel { Name = "Allamanda Laguna Phuket", Country = "Таиланд", Stars = 4 });
            context.Hotels.Add(new Hotel { Name = "Aurora Oriental Resort", Country = "Египет", Stars = 5 });
            context.Hotels.Add(new Hotel { Name = "Midas Hotel", Country = "Италия", Stars = 4 });
            context.Hotels.Add(new Hotel { Name = "The Hub Hotel", Country = "Италия", Stars = 4 });
            context.Hotels.Add(new Hotel { Name = "Saritas Hotel", Country = "Турция", Stars = 4 });
            context.Hotels.Add(new Hotel { Name = "Kemer Millenium Resort", Country = "Турция", Stars = 5 });
            context.Hotels.Add(new Hotel { Name = "Al Waleed Hotel", Country = "Иордания", Stars = 3 });
            context.Hotels.Add(new Hotel { Name = "Star Plaza Hotel", Country = "Иордания", Stars = 5 });
            context.Hotels.Add(new Hotel { Name = "Fontana Hotel Bali", Country = "Индонезия", Stars = 4 });
            context.Hotels.Add(new Hotel { Name = "Ohana Hotel Kuta", Country = "Индонезия", Stars = 4 });
            //насоздавать входных данных
            /*context.Tours.Add
            context.Hotels.Add
            context.Transport.Add*/

            context.SaveChanges();
        }
    }
}
