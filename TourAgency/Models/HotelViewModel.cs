using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourAgency.Models
{
    public enum StarsCount { Одна = 1 , Две, Три, Четыре, Пять }
    public class HotelViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public StarsCount Stars { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }
    }
}