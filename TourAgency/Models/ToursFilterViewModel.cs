using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourAgency.Models
{
    public class ToursFilterViewModel
    {
        public IEnumerable<TourDTO> Tours { get; set; }
        public SelectList Type { get; set; }
        public SelectList Countries { get; set; }
        public SelectList Regions { get; set; }
    }
}