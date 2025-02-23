using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccBackEnd.Domain.Entities
{
    public class AgenReservaLocalSubtotal
    {
        public int Id { get; set;}
        public required int ReservaId { get; set;}
        public int Quantidade { get; set;}
        public required int AgenciaServiced { get; set;}
        public decimal Subtotal { get; set;}
    }
}