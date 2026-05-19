using Microsoft.AspNetCore.Mvc;
using StreamFinder.Api.Models;
using StreamFinder.Api.Services;

namespace StreamFinder.Api.Controllers;

[ApiController]
[Route("api/titles")]
public class TitlesController : ControllerBase
{
    private readonly WatchmodeService _watchmode;

    public TitlesController(WatchmodeService watchmode)
    {
        _watchmode = watchmode;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TitleDetail>> GetDetail(int id)
    {
        var detail = await _watchmode.GetTitleDetailAsync(id);
        if (detail == null)
            return NotFound(new { error = "Title not found." });

        return Ok(detail);
    }

    [HttpGet("{id}/sources")]
    public async Task<ActionResult<List<TitleSource>>> GetSources(int id, [FromQuery] string? region)
    {
        var sources = await _watchmode.GetTitleSourcesAsync(id, region);
        return Ok(sources);
    }
}
