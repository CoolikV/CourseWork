﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTO
{
    public class TransportOrderDTO
    {
        public string Email { get; set; }
        public int TransportType { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
