using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccBackEnd.Domain.Entities;
using TccBackEnd.Service;
using TccBackEnd.UseCases.Local.Dtos;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocalController : Controller
{
    private readonly LocalService _localService;
    private readonly ILogger<LocalController> _logger;

    public LocalController(LocalService localService, ILogger<LocalController> logger)
    {
        _localService = localService;
        _logger = logger;
    }
    
    [Authorize]
    [HttpPost("create")]
    public async Task<IActionResult> Create(CadastrarLocalDto dto)
    {
        var userIdClaim = User.FindFirst("id");
        if (userIdClaim == null)
            return Unauthorized(new { Error = "Usuário não autenticado" });
        
        int userId = int.Parse(userIdClaim.Value);
    
        var result = await _localService.Cadastrar.Executar(userId, dto);
        _logger.LogInformation("Solicitação de cadastro de local de eventos");
        return result.IsSuccess
            ? Ok(result)
            : BadRequest(new { Error = result.ErrorMessage });
    }
    
    [Authorize]
    [HttpPut("update")]
    public async Task<IActionResult> Update(CadastrarLocalDto dto)
    {
        var userIdClaim = User.FindFirst("id");
        if (userIdClaim == null)
            return Unauthorized(new { Error = "Usuário não autenticado" });
        
        int userId = int.Parse(userIdClaim.Value);
    
        var result = await _localService.Atualizar.Executar(userId, dto);
        _logger.LogInformation("Solicitação de cadastro de local de eventos");
        return result.IsSuccess
            ? Ok(result)
            : BadRequest(new { Error = result.ErrorMessage });
    }
    
    [AllowAnonymous]
    [HttpGet("get/{id:int}")]
    public async Task<IActionResult> GetById(int id, CadastrarLocalDto dto)
    {
        var userIdClaim = User.FindFirst("id");
        if (userIdClaim == null)
            return Unauthorized(new { Error = "Usuário não autenticado" });
        
        int userId = int.Parse(userIdClaim.Value);
    
        var result = await _localService.ObterPorId.Executar(userId, dto);
        _logger.LogInformation("Solicitação de cadastro de local de eventos");
        return result.IsSuccess
            ? Ok(result)
            : BadRequest(new { Error = result.ErrorMessage });
    }
    [AllowAnonymous]
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll(CadastrarLocalDto dto)
    {
        var userIdClaim = User.FindFirst("id");
        if (userIdClaim == null)
            return Unauthorized(new { Error = "Usuário não autenticado" });
        
        int userId = int.Parse(userIdClaim.Value);
    
        var result = await _localService.Cadastrar.Executar(userId, dto);
        _logger.LogInformation("Solicitação de cadastro de local de eventos");
        return result.IsSuccess
            ? Ok(result)
            : BadRequest(new { Error = result.ErrorMessage });
    }

}