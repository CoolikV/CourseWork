using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BLL.DTO;

namespace TourAgency.Models
{
    public enum TransportType { Авиаперелёт = 1, Автобус, Поезд, Паром }
    public class TransportOrderViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public TransportType TransportType { get; set; }
        public DateTime Date { get; set; }
    }
}