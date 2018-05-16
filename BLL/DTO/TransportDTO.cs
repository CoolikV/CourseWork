using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTO
{
    public enum TransportType { Авиаперелёт, Автобус, Поезд, Паром }
    public class TransportDTO
    {
 
        public int Id { get; set; }
        public TransportType TransportType { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
