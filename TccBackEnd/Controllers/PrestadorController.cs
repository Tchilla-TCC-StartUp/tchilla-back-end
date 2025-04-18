using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccBackEnd.Service;
using TccBackEnd.UseCases.Local.Dtos;
using TccBackEnd.UseCases.PrestadorServico.Dtos;

namespace TccBackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrestadorController : ControllerBase
{
    private readonly ILogger<PrestadorController> _logger;
    private readonly PrestadorService _prestadorService;
    public PrestadorController(ILogger<PrestadorController> logger, PrestadorService prestadorService)
    {
        _logger = logger;
        _prestadorService = prestadorService;
    }

    [Authorize]
    [HttpGet("getInfoByToken")]
    public async Task<IActionResult> ObterPrestadorPorToken()
    {
        var userIdClaim = User.FindFirst("id");
        if (userIdClaim == null) 
            return Unauthorized(new { Error = "Usuário não autenticado" });

        var userId = int.Parse(userIdClaim.Value);
        /*Result<UsuarioOutputDto?> result = await _usuarioService.ObterPorId.Executar(userId);
        _logger.LogInformation("Solicitação de usuario por token.");
        
        return result.IsSuccess 
            ? Ok(result) 
            : BadRequest(new { Error = result.ErrorMessage });**/
        return Ok();
    }
    
    // [Authorize]
    // [HttpPut("update")]
    // public async Task<IActionResult> Update(CadastrarLocalDto dto)
    // {
    //     var userIdClaim = User.FindFirst("id");
    //     if (userIdClaim == null)
    //         return Unauthorized(new { Error = "Usuário não autenticado" });
        
    //     int userId = int.Parse(userIdClaim.Value);
    
    //     var result = await _prestadorService.Cadastrar.Executar(userId, dto);
    //     _logger.LogInformation("Solicitação de cadastro de local de eventos");
    //     return result.IsSuccess
    //         ? Ok(result)
    //         : BadRequest(new { Error = result.ErrorMessage });
    // }
    
    // [AllowAnonymous]
    // [HttpGet("get/{id:int}")]
    // public async Task<IActionResult> GetById(int id, CadastrarLocalDto dto)
    // {
    //     var userIdClaim = User.FindFirst("id");
    //     if (userIdClaim == null)
    //         return Unauthorized(new { Error = "Usuário não autenticado" });
        
    //     int userId = int.Parse(userIdClaim.Value);
    
    //     var result = await _prestadorService.ObterPorId.Executar(userId, dto);
    //     _logger.LogInformation("Solicitação de cadastro de local de eventos");
    //     return result.IsSuccess
    //         ? Ok(result)
    //         : BadRequest(new { Error = result.ErrorMessage });
    // }
    [AllowAnonymous]
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var userIdClaim = User.FindFirst("id");
        if (userIdClaim == null)
            return Unauthorized(new { Error = "Usuário não autenticado" });
        
        int userId = int.Parse(userIdClaim.Value);
    
        var result = await _prestadorService.ObterTodos.Executar();
        _logger.LogInformation("Solicitação de cadastro de local de eventos");
        return result.IsSuccess
            ? Ok(result)
            : BadRequest(new { Error = result.ErrorMessage });
    }
}