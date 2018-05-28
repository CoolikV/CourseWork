using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTO
{
    public class HotelOrderDTO
    {
        public int HotelId { get; set; }
        public DateTime EntranceDate { get; set; }
        public DateTime EvictionDate { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}
