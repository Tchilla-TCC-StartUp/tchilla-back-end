using TccBackEnd.Domain.Enums;

namespace TccBackEnd.UseCases.Servico.Dtos
{
    public class ServicoPrestadorMidiaDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public TipoMedia Tipo { get; set; } 
    }
}