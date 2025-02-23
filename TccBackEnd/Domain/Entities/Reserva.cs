using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccBackEnd.Domain.Entities
{
    public class Reserva
    {
        public int  Id { get; set; } 
        public required int ClienteId { get; set; }
        public DateTime DataReserva { get; set; }
        public string Confirmacao { get; set; }
        public int Total { get; set; }
    }
}