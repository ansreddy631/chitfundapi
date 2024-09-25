using DataAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MonthController : ControllerBase
{

    private readonly MyDbContext _context;
    private readonly ILogger<MonthController> _logger;

    public MonthController(ILogger<MonthController> logger, MyDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Month>>> GetItems()
    {
        return await _context.Months.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Month>> CreateItem(Person item)
    {
        _context.Persons.Add(item);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetItems), new { id = item.Id }, item);
    }
}

