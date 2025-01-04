using Microsoft.AspNetCore.Mvc;
using TccBackEnd.UseCases.Supervisor.Cadastrar;
using TccBackEnd.UseCases.Supervisor.Dtos;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SupervisorController : Controller
{
    private readonly ILogger<SupervisorController> _logger;
    private readonly CadastrarSupervisorUseCase _cadastrarSupervisorUseCase;
    public SupervisorController(CadastrarSupervisorUseCase cadastrarSupervisorUseCase)
    {
        _cadastrarSupervisorUseCase = cadastrarSupervisorUseCase;
    }

    
    [HttpPost("cadastrar")]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarSupervisorDto dto)
    {
        try
        {
            var id = await _cadastrarSupervisorUseCase.Executar(dto);
            _logger.Log(LogLevel.Information,$"Cadastrado Supervisor {id} com sucesso");
            return CreatedAtAction(nameof(Cadastrar), new { id }, null);
        }
        catch (Exception e)
        {
            return BadRequest(new {Error = e.Message});
        }
    }
}