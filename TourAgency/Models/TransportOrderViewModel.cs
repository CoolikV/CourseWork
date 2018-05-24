using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BLL.DTO;

namespace TourAgency.Models
{
    public class TransportOrderViewModel
    {
        [Key]
        public int TransportId { get; set; }
        public string Email { get; set; }
        public TransportDTO Transport { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}