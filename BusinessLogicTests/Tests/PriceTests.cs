using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BusinessModels;
using NUnit.Framework;

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
            // arrange
            int starsCount = 5;
            DateTime evictionDate = new DateTime(2018, 7, 4);
            DateTime entranceDate = new DateTime(2018, 7, 14);

            // act
            Price price = new Price(starsCount, evictionDate, entranceDate);

            // assert
            Assert.AreEqual(price.CalculatePrice(), 0m);
        }

    }
}    

