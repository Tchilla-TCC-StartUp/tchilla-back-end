using Microsoft.AspNetCore.Mvc;
using TccBackEnd.Service;

namespace TccBackEnd.Controllers;

public class LocalController : Controller
{
    private readonly LocalService _localService;

    public LocalController(LocalService localService)
    {
        _localService = localService;
    }
    
}