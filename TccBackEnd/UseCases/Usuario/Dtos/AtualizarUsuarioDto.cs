using System.Text.Json.Serialization;
using TccBackEnd.Domain.Enums;

namespace TccBackEnd.UseCases.Usuario.Dtos;

public class AtualizarUsuarioDto
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
}