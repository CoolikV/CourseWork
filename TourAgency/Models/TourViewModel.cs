﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourAgency.Models
{
    public class TourViewModel
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите название")]
        [Display(Name ="Название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите страну")]
        [Display(Name = "Страна")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите регион")]
        [Display(Name = "Регион")]
        public string Region { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите цену")]
        [Display(Name = "Цена")]
        [Range(1000,double.MaxValue,ErrorMessage ="Проверьте правильность цены")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите тип")]
        [Display(Name = "Тип")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите дату")]
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}