using Microsoft.AspNetCore.Mvc;
using TccBackEnd.UseCases.AgenciaEventos.Cadastrar;
using TccBackEnd.UseCases.AgenciaEventos.Dtos;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AgenciaEventosController : ControllerBase
{
    private readonly ILogger<AgenciaEventosController> _logger;
    private readonly CadastrarAgenciaEventosUseCase _cadastrarAgenciaEventosUseCase;
    public AgenciaEventosController(CadastrarAgenciaEventosUseCase cadastrarAgenciaEventosUseCase)
    {
        _cadastrarAgenciaEventosUseCase = cadastrarAgenciaEventosUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarAgenciaEventosDto dto)
    {
        try
        {
            var id = await _cadastrarAgenciaEventosUseCase.Executar(dto);
            _logger.Log(LogLevel.Information, $"Cadastrada Agencia de Eventos {id} com sucesso");
            return CreatedAtAction(nameof(Cadastrar), new {id}, null);
        }
        catch (Exception e)
        {
            return BadRequest(new {Error = e.Message});
        }
    }

    [HttpPut]
    public async Task<IActionResult> Atualizar([FromBody] AtualizarAgenciaEventosDto dto)
    {
        try
        {
            
            return CreatedAtAction(nameof(Atualizar), new { dto }, null);
        }
        catch (Exception e)
        {
            return BadRequest(new {Error = e.Message});
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> ObterPorId([FromQuery] long id)
    {
        try
        {
            return CreatedAtAction(nameof(ObterPorId), "ksks", null);
        }
        catch (Exception e)
        {
            return BadRequest(new {Error = e.Message});
        }
    }
    
    
}