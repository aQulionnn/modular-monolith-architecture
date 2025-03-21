using Microsoft.AspNetCore.Mvc;
using Modules.Pianos.Entities;
using Modules.Pianos.Interfaces;

namespace Modules.Pianos.Controllers;

[Route("api/pianos")]
[ApiController]
public class PianoController(IPianoRepository pianoRepository) : ControllerBase
{
    private readonly IPianoRepository _pianoRepository = pianoRepository;
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] Piano piano)
    {
        var createdPiano = await _pianoRepository.CreateAsync(piano);
        return Ok(createdPiano.Id);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var piano = await _pianoRepository.GetByIdAsync(id);
        if (piano == null) return NotFound();
        return Ok(piano);
    }
}