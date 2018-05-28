using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using BLL.Services;
using DAL.Interfaces;
using DAL.Entities;
using NUnit.Framework;
using BLL.DTO;
using BLL.Infrastructure;
using TourAgency.App_Start;

namespace BusinessLogicTests.Tests
{
    [TestFixture]
    public class OtherOrderServiceTests
    {
        [Test]
        public void HotelOrder_Test()
        {
            //Arrange
            bool orderSucessful = false;

            var hotelsDbMock = new Mock<IRepository<Hotel>>();
            hotelsDbMock.Setup(a => a.GetByID(1)).Returns(new Hotel { Id = 1 });

            var hotelOrdMock = new Mock<IRepository<HotelBooking>>();
            hotelOrdMock.Setup(a => a.Insert(It.IsAny<HotelBooking>())).Callback(() => orderSucessful = true);

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.Hotels).Returns(hotelsDbMock.Object);
            uowMock.Setup(uow => uow.HotelOrders).Returns(hotelOrdMock.Object);

            var entrance = new DateTime(2018, 6, 2);
            var eviction = new DateTime(2018, 6, 12);

            var orderService = new OtherOrderService(uowMock.Object);
            var hotelOrderDto = new HotelOrderDTO { HotelId = 1, EntranceDate = entrance, EvictionDate = eviction };
            //Act
            orderService.OrderHotel(hotelOrderDto);

            //Assert
            Assert.IsTrue(orderSucessful);
            Assert.Throws<ValidationException>(() => orderService.OrderHotel(new HotelOrderDTO { HotelId = 2 }));
        }

        [Test]
        public void TransportOrder_Test()
        {
            //Arrange
            bool orderSucessful = false;

            var transportOrdMock = new Mock<IRepository<TransportBooking>>();
            transportOrdMock.Setup(a => a.Insert(It.IsNotNull<TransportBooking>())).Callback(() => orderSucessful = true);

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.TransportOrders).Returns(transportOrdMock.Object);

            var orderService = new OtherOrderService(uowMock.Object);

            //Act
            orderService.OrderTransport(new TransportOrderDTO { });
            //Assert
            Assert.IsTrue(orderSucessful);
        }
    }
}
