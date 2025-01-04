using Microsoft.AspNetCore.Mvc;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.AgenciaEventos.Atualizar;
using TccBackEnd.UseCases.AgenciaEventos.Cadastrar;
using TccBackEnd.UseCases.AgenciaEventos.Dtos;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AgenciaEventosController : ControllerBase
{
    private readonly ILogger<AgenciaEventosController> _logger;
    private readonly CadastrarAgenciaEventosUseCase _cadastrarAgenciaEventosUseCase;
    private readonly AtualizarAgenciaEventosUseCase _atualizarAgenciaEventosUseCase;
    public AgenciaEventosController(CadastrarAgenciaEventosUseCase cadastrarAgenciaEventosUseCase)
    {
        _cadastrarAgenciaEventosUseCase = cadastrarAgenciaEventosUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarAgenciaEventosDto dto)
    {
        Result<string> result = await _cadastrarAgenciaEventosUseCase.Executar(dto);
        _logger.LogInformation($"Agencia de eventos cadastrada com sucesso");
        return (result.IsSuccess) ? CreatedAtAction(nameof(Cadastrar), result, null) : BadRequest(new {Error = result.ErrorMessage});
    }

    [HttpPut]
    public async Task<IActionResult> Atualizar([FromBody] AtualizarAgenciaEventosDto dto)
    {
        Result<string> result = await _atualizarAgenciaEventosUseCase.Executar(dto);
        _logger.LogInformation($"Agencia de eventos cadastrada com sucesso");
        return (result.IsSuccess) ? CreatedAtAction(nameof(Cadastrar), result, null) : BadRequest(new {Error = result.ErrorMessage});
    }
    
    [HttpGet]
    public async Task<IActionResult> ObterPorId([FromQuery] long id)
    {
        //Result<AgenciaEventosOutputDto?> result = await 
    }
    
    
}