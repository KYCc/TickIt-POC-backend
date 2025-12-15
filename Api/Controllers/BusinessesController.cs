using Api.Dtos;
using BL.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BusinessesController : ControllerBase
{
    private readonly IBusinessService _businessService;
    private readonly ILogger<BusinessesController> _logger;

    public BusinessesController(IBusinessService businessService, ILogger<BusinessesController> logger)
    {
        _businessService = businessService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BusinessDto>>> GetAll()
    {
        var businesses = await _businessService.GetAll();
        var dtos = businesses.Select(business => new BusinessDto
        {
            Id = business.Id,
            Name = business.Name
        });

        return Ok(dtos);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BusinessDto>> Get(Guid id)
    {
        var business = await _businessService.GetById(id);
        if (business == null) return NotFound();
        var dto = new BusinessDto
        {
            Id = business.Id,
            Name = business.Name
        };

        return Ok(dto);
    }

    //TODO return CreatedAtAction
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] string businessName)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(businessName)) return BadRequest();
            await _businessService.Add(businessName);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError("{Message}", e.Message);
            return BadRequest();
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _businessService.DeleteById(id);
            return NoContent(); // 204 
        }
        catch (Exception e)
        {
            _logger.LogError("Error deleting business with ID {Id}", id);
            return BadRequest();
        }
    }
}