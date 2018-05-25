using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BLL.DTO;

namespace TourAgency.Models
{
    public enum TransportType { Авиаперелёт = 5, Автобуc = 2, Поезд = 3, Паром = 4 }
    public class TransportOrderViewModel
    {
        public string Email { get; set; }
        public TransportType TransportType { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}