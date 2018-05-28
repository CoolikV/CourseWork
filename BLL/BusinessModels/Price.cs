using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.BusinessModels
{
    public class Price
    {
        public Price(int starsCount, DateTime evictionDate, DateTime entranceDate)
        {
            _stars_Count= starsCount;
            _eviction = evictionDate;
            _entrance = entranceDate;
        }

        private int _stars_Count;
        private DateTime _eviction;
        private DateTime _entrance;
        public decimal CalculatePrice()
        {
            return (decimal)(_eviction - _entrance).TotalDays * 150 * _stars_Count;
        }
    }
}
