using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyHubAPI.Models;

namespace PropertyHubAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertyController : ControllerBase
{

  private readonly PropertyHubContext _context;

  public PropertyController(PropertyHubContext context)
  {
    _context = context;
  }

  [HttpGet("GetAllProperties")]
  public async Task<IActionResult> GetAllProperties()
  {
    var properties = await _context.Properties.ToListAsync();
      return Ok(properties);
  }

}