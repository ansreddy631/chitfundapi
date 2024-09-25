using DataAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{

    private readonly MyDbContext _context;
    private readonly ILogger<PersonController> _logger;

    public PersonController(ILogger<PersonController> logger, MyDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Person>>> GetItems()
    {
        return await _context.Persons.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Person>> CreateItem(Person item)
    {
        _context.Persons.Add(item);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetItems), new { id = item.Id }, item);
    }
}


