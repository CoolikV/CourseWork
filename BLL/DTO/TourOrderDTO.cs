using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTO
{
    public class TourOrderDTO
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
    }
}
