using Microsoft.AspNetCore.Mvc;
using TccBackEnd.UseCases.Supervisor.Dtos;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SupervisorController : Controller
{
    private readonly ILogger<SupervisorController> _logger;
    public SupervisorController(ILogger<SupervisorController> logger)
    {
        _logger = logger;
    }

    
    [HttpPost("create")]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarSupervisorDto dto)
    {
        return Ok();
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> Atualizar([FromBody] CadastrarSupervisorDto dto)
    {
        return Ok();
    }
    
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> RemoverPorid(int id)
    {
        return Ok();
    }
    [HttpGet("getAll")]
    public async Task<IActionResult> ObterTodos([FromBody] CadastrarSupervisorDto dto)
    {
        return Ok();
    }
}