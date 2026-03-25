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
    var properties = await _context.Properties
      .AsNoTracking()
      .Select(property => new
      {
        id = property.Id,
        title = property.Title,
        description = property.Description,
        address = property.Address,
        city = property.City,
        state = property.State,
        zipCode = property.ZipCode,
        price = property.Price,
        propertyType = property.PropertyType,
        bedrooms = property.Bedrooms,
        bathrooms = property.Bathrooms,
        squareFootage = property.SquareFootage,
        yearBuilt = property.YearBuilt,
        status = property.Status,
        latitude = property.Latitude,
        longitude = property.Longitude,
        dateListed = property.DateListed,
        agentId = property.AgentId,
        createdAt = property.CreatedAt,
        updatedAt = property.UpdatedAt,
        propertyImages = property.PropertyImages
          .OrderBy(image => image.SortOrder)
          .Select(image => new
          {
            id = image.Id,
            propertyId = image.PropertyId,
            imageUrl = image.ImageUrl,
            isPrimary = image.IsPrimary,
            sortOrder = image.SortOrder,
          })
          .ToList(),
      })
      .ToListAsync();

    return Ok(properties);
  }

}