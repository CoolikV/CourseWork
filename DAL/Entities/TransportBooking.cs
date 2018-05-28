using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class TransportBooking
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Email { get; set; }
        public int TransportType { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
