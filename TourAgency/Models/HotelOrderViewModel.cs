using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BLL.DTO;

namespace TourAgency.Models
{
    public class HotelOrderViewModel
    {
        [Key]
        public int HotelId { get; set; }
        public string Email { get; set; }
        public HotelDTO Hotel { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Дата заезда")]
        public DateTime EntranceDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата отъезда")]
        public DateTime EvictionDate { get; set; }
    }
}