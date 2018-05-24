using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BLL.DTO;

namespace TourAgency.Models
{
    public class TourOrderViewModel
    {
        [Key]
        public int TourId { get; set; }
        public TourDTO Tour { get; set; }
        public string Email { get; set; }
    }
}