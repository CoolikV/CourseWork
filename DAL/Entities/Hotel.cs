using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        //public decimal Price { get; set; }
        public string Country { get; set; }
        private ICollection<HotelBooking> HotelOrders { get; set; }
    }
}
