using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    enum TransportType { Авиаперелёт, Автобус, Поезд, Паром}
    public class Transport
    {
        [Key]
        public int Id { get; set; }
        private TransportType TransportType  { get; set; }
        public decimal Price { get; set; }
        private DateTime Date { get; set; }

        private ICollection<TransportBooking> TransportOrders { get; set; }
    }
}
