using Microsoft.AspNetCore.Mvc;
using Modules.Violins.Entities;
using Modules.Violins.Interfaces;

namespace Modules.Violins.Controllers;

[Route("api/violins")]
[ApiController]
public class ViolinController(IViolinRepository violinRepository) : ControllerBase
{
    private readonly IViolinRepository _violinRepository = violinRepository;

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] Violin violin)
    {
        var createdViolin = await _violinRepository.CreateAsync(violin);
        return Ok(createdViolin.Id);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var violin = await _violinRepository.GetByIdAsync(id);
        if (violin == null) return NotFound();
        return Ok(violin);
    }
}