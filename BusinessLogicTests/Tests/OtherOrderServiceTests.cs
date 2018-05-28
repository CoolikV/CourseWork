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

namespace BusinessLogicTests.Tests
{
    [TestFixture]
    public class OtherOrderServiceTests
    {
        [Test]
        public void OrderHotel_Test()
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

            var orderService = new OtherOrderService(uowMock.Object);

            //Act
            orderService.OrderHotel(new HotelOrderDTO { HotelId = 1 });

            //Assert
            Assert.IsTrue(orderSucessful);
        }
    }
}
