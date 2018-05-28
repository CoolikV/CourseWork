using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BusinessModels;
using NUnit.Framework;
using BLL.Infrastructure;
using Moq;
using BLL.Services;
using DAL.Interfaces;
using DAL.Entities;
using BLL.DTO;

namespace BusinessLogicTests.Tests
{
    [TestFixture]
    public class PriceTests
    {

        [Test]
        public void GetCalculatePrice()
        {
            // arrange
            int starsCount = 5;
            DateTime evictionDate = new DateTime(2018, 7, 14);
            DateTime entranceDate = new DateTime(2018, 7, 4);

            // act
            Price price = new Price(starsCount, evictionDate, entranceDate);

            // assert
            Assert.AreEqual(price.CalculatePrice(), 7500m);
        }

        [Test]
        public void GetCalculatePriceWrong()
        {
            var hotelsDbMock = new Mock<IRepository<Hotel>>();
            hotelsDbMock.Setup(a => a.GetByID(1)).Returns(new Hotel { Id = 1 });

            var eviction = new DateTime(2018, 6, 2);
            var entrance = new DateTime(2018, 6, 12);
            var hotelOrdMock = new Mock<IRepository<HotelBooking>>();

            var hotelDto = new HotelOrderDTO { HotelId = 1, EntranceDate = entrance, EvictionDate = eviction };
            var uowMock = new Mock<IUnitOfWork>();
  
            uowMock.Setup(uow => uow.Hotels).Returns(hotelsDbMock.Object);
            uowMock.Setup(uow => uow.HotelOrders).Returns(hotelOrdMock.Object);

            var orderService = new OtherOrderService(uowMock.Object);

            Assert.Throws<ValidationException>(() => orderService.OrderHotel(hotelDto));
        }

    }
}    

