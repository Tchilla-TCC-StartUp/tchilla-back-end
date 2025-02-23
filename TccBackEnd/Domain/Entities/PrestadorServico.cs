using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccBackEnd.Domain.Entities
{
    public class PrestadorServico
    {
        public int Id { get; set;}
        public string Nome { get; set; }
        public decimal preco { get; set; }
        public required int PrestadorId { get; set; }
    }
}