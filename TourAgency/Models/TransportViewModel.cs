using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourAgency.Models
{
    public enum TransportType { Авиаперелёт, Автобус , Поезд, Паром }
    public class TransportViewModel
    {
        [Key]
        public int Id { get; set; }
        public TransportType TransportType { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}