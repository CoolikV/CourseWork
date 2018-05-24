using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Tour
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type  { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }

        private ICollection<TourBooking> TourOrders { get; set; }
    }
}
