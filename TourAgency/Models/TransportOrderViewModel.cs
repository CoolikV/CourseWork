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
        [Required(ErrorMessage ="Укажите желаемый вид транспорта")]
        [Display(Name ="Вид транспорта")]
        public TransportType TransportType { get; set; }
        [Required(ErrorMessage = "Укажите дату отправления")]
        [Display(Name = "Дата отправления")]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }
    }
}