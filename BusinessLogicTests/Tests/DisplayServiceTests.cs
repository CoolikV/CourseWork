using System;
using Moq;
using System.Collections.Generic;
using System.Linq;
using BLL.Services;
using DAL.Interfaces;
using DAL.Entities;
using TourAgency.App_Start;
using NUnit.Framework;
namespace BusinessLogicTests
{
    [TestFixture]
    public class DisplayServiceTests
    {
        [OneTimeSetUp]
        public void Initial()
        {
            AutoMapperConfig.InitializeConfig();
        }
        [Test]
        public void GetAllHotelsTest()
        {
            //Arrange

            var hotelsDbMock = new Mock<IRepository<Hotel>>();
            hotelsDbMock.Setup(a => a.Get(null, null, "")).Returns(new List<Hotel>()
            {
                new Hotel { Id = 1, Country = "Test", Name = "Name1", Stars = 2 },
                new Hotel { Id = 2, Country = "Test1", Name = "Kadabra", Stars = 3 }
            });
            
            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.Hotels).Returns(hotelsDbMock.Object);
            
            var display = new DisplayService(uowMock.Object);

            //Act
            var actual = display.GetAllHotels().Count();

            //Assert
            Assert.AreEqual(2, actual);
        }

        [Test]
        public void GetAllToursTest()
        {
            //Arrange
            var toursDbMock = new Mock<IRepository<Tour>>();
            toursDbMock.Setup(a => a.Get(null, null, "")).Returns(new List<Tour>()
            {
                new Tour{ Id = 1, Country = "USA", Date = DateTime.Now, Name = "Name1", Price = 1234, Region = "L.A", Type = "Excursion"},
                new Tour{ Id = 2, Country = "Ukraine", Date = DateTime.Now, Name = "Name2", Price = 1234, Region = "Venice", Type = "Excursion"},
                new Tour{ Id = 2, Country = "Germany", Date = DateTime.Now, Name = "Name2", Price = 1234, Region = "Hamburg", Type = "Excursion" }
            });

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.Tours).Returns(toursDbMock.Object);

            var display = new DisplayService(uowMock.Object);

            //Act
            var actual = display.GetAllTours().Count();

            //Assert
            Assert.AreEqual(3, actual);
        }

        [Test]
        public void GetTourByIdTest()
        {
            //Arrange
            var toursDbMock = new Mock<IRepository<Tour>>();
            toursDbMock.Setup(a => a.GetByID(2)).Returns(new Tour { Id = 2 });
            toursDbMock.Setup(a => a.GetByID(It.Is<int>(i => i < 0))).Throws<ArgumentException>();
            toursDbMock.Setup(a => a.GetByID(It.Is<int?>(i => i == null))).Throws<ArgumentNullException>();

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.Tours).Returns(toursDbMock.Object);

            var service = new DisplayService(uowMock.Object);

            //Act
            var actual = service.GetTour(2).Id;

            //Assert
            Assert.AreEqual(2, actual);
        }

        [Test]
        public void GetHotelByIdTest()
        {
            //Arrange
            var hotelsDbMock = new Mock<IRepository<Hotel>>();
            hotelsDbMock.Setup(a => a.GetByID(1)).Returns(new Hotel { Id = 1 });
            hotelsDbMock.Setup(a => a.GetByID(It.Is<int>(i => i != 1))).Throws<NullReferenceException>();

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.Hotels).Returns(hotelsDbMock.Object);
            var service = new DisplayService(uowMock.Object);

            //Act
            var actual = service.GetHotel(1).Id;

            //Assert
            Assert.AreEqual(1, actual);
        }

        [Test]
        public void GetCountriesTest()
        {
            //Arrange
            //AutoMapperConfig.InitializeConfig();

            var toursDbMock = new Mock<IRepository<Tour>>();
            toursDbMock.Setup(a => a.Get(null, null, "")).Returns(new List<Tour>()
            {
                new Tour { Id = 1, Country = "Gonduras", Name = "Name1"},
                new Tour { Id = 2, Country = "Nigeria", Name = "Name2"}
            });

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.Tours).Returns(toursDbMock.Object);

            var display = new DisplayService(uowMock.Object);

            //Act
            var actual = display.GetCountries();

            //Assert
            Assert.AreEqual(new List<string>() { "Все", "Gonduras", "Nigeria" }, actual);
        }

        [Test]
        public void GetRegionsTest()
        {
            //Arrange

            var toursDbMock = new Mock<IRepository<Tour>>();
            toursDbMock.Setup(a => a.Get(null, null, "")).Returns(new List<Tour>()
            {
                new Tour { Id = 1, Country = "Gonduras", Name = "Name1", Region = "Gondurasij"},
                new Tour { Id = 2, Country = "Nigeria", Name = "Name2", Region = "Nigerijskij"}
            });

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.Tours).Returns(toursDbMock.Object);

            var display = new DisplayService(uowMock.Object);

            //Act
            var actual = display.GetRegions();

            //Assert
            Assert.AreEqual(new List<string>() { "Все", "Gondurasij", "Nigerijskij" }, actual);
        }

        [Test]
        public void FindTour_Returns_0_Test()
        {
            //Arrange
           // AutoMapperConfig.InitializeConfig();

            var toursDbMock = new Mock<IRepository<Tour>>();
            toursDbMock.Setup(a => a.Get(t => t.Name == "Name2", null, "")).Returns(new List<Tour>()
            {
                new Tour { Id = 1, Name = "Name2"},
                new Tour { Id = 2, Name = "Name2"}
            });
            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.Tours).Returns(toursDbMock.Object);

            var display = new DisplayService(uowMock.Object);
            //Act
            var actual_1 = display.FindTour("Name1");

            //Assert
            Assert.AreEqual(0, actual_1.Count());
        }
    }
}