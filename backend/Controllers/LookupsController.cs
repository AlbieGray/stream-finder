using Microsoft.AspNetCore.Mvc;
using StreamFinder.Api.Models;
using StreamFinder.Api.Services;

namespace StreamFinder.Api.Controllers;

[ApiController]
[Route("api")]
public class LookupsController : ControllerBase
{
    private readonly WatchmodeService _watchmode;

    public LookupsController(WatchmodeService watchmode)
    {
        _watchmode = watchmode;
    }

    [HttpGet("sources")]
    public async Task<ActionResult<List<Source>>> GetSources()
    {
        var sources = await _watchmode.GetSourcesAsync();
        return Ok(sources);
    }

    [HttpGet("regions")]
    public async Task<ActionResult<List<Region>>> GetRegions()
    {
        var regions = await _watchmode.GetRegionsAsync();
        return Ok(regions);
    }
}
