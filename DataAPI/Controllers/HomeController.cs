using DataAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataAPI.Controllers;

[ApiController]
public class HomeController : ControllerBase
{

    private readonly MyDbContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    [Route("/")]
    public string Get()
    {
        return "OK";
    }
}

