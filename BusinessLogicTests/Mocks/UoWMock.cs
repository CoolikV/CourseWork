using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entities;
using BLL.Interfaces;

namespace BusinessLogicTests.Mocks
{
    public class UoWMock : IUnitOfWork
    {
        private IRepository<Tour> _tours;
        private IRepository<Hotel> _hotels;
        private IRepository<TransportBooking> _transportOrders;
        private IRepository<TourBooking> _tourOrders;
        private IRepository<HotelBooking> _hotelOrders;

        public List<Tour> toursList = new List<Tour>();
        public List<Hotel> hotelsList = new List<Hotel>();
        public List<TransportBooking> transportBookingList = new List<TransportBooking>();
        public List<HotelBooking> hotelsBookingList = new List<HotelBooking>();
        public List<TourBooking> toursBookingList = new List<TourBooking>();

        public UoWMock()
        {
            hotelsList.Add(new Hotel { Name = "Test1", Country = "TetsCountry1", Id = 1, Stars = 4 });
            hotelsList.Add(new Hotel { Name = "Test2", Country = "TetsCountry2", Id = 2, Stars = 2 });
            hotelsList.Add(new Hotel { Name = "Test3", Country = "TetsCountry3", Id = 3, Stars = 1 });


            toursList.Add(new Tour { Name = "Test1", Country = "Country1", Id = 1, Date = new DateTime(2018, 12, 04), Price = 1234, Region = "Region1", Type = "Горящий" });
            toursList.Add(new Tour { Name = "Test2", Country = "Country2", Id = 2, Date = new DateTime(2018, 10, 28), Price = 2214, Region = "Region2", Type = "Екскурсия" });

            transportBookingList.Add(new TransportBooking { Id = 1, DepartureDate = new DateTime(2018, 11, 21), Price = 1234, Email = "example@mail.ru", TransportType = 2 });
        }

    }
}
