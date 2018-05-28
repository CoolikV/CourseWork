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

namespace BusinessLogicTests.Tests
{
    [TestFixture]
    public class TourOrderServiceTests
    {
        [Test]
        public void TourOrderTest()
        {
            //Arrange
            bool orderSucessful = false;

            var toursDbMock = new Mock<IRepository<Tour>>();
            toursDbMock.Setup(a => a.GetByID(1)).Returns(new Tour { Id = 1 });

            var tourOrdMock = new Mock<IRepository<TourBooking>>();
            tourOrdMock.Setup(a => a.Insert(It.IsAny<TourBooking>())).Callback(() => orderSucessful = true);

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.Tours).Returns(toursDbMock.Object);
            uowMock.Setup(uow => uow.TourOrders).Returns(tourOrdMock.Object);

            var orderService = new TourOrderService(uowMock.Object);

            //Act
            orderService.MakeOrder(new TourOrderDTO { TourId = 1 });
            //Assert
            Assert.IsTrue(orderSucessful);
            Assert.Throws<ValidationException>(() => orderService.MakeOrder(new TourOrderDTO { TourId = 2 }));
        }
    }
}
