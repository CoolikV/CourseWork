using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class TourBooking
    {
        [Key]
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string Email { get; set; }

        public int TourId { get; set; }
        private Tour Tour { get; set; }

        public DateTime Date { get; set; }
    }
}
