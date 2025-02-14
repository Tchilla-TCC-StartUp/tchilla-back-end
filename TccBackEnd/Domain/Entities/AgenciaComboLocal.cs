using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccBackEnd.Domain.Entities
{
    public class AgenciaComboLocal
    {
        public string Nome { get; set; }
        public required int AgenciaComboId  { get; set; }
        public required int AgenciaServicoId { get; set; }
    }
}