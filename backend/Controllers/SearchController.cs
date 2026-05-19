using Microsoft.AspNetCore.Mvc;
using StreamFinder.Api.Models;
using StreamFinder.Api.Services;

namespace StreamFinder.Api.Controllers;

[ApiController]
[Route("api/search")]
public class SearchController : ControllerBase
{
    private readonly WatchmodeService _watchmode;

    public SearchController(WatchmodeService watchmode)
    {
        _watchmode = watchmode;
    }

    [HttpGet]
    public async Task<ActionResult<SearchResponse>> Search([FromQuery] string q)
    {
        if (string.IsNullOrWhiteSpace(q))
            return BadRequest(new { error = "Query parameter 'q' is required." });

        var results = await _watchmode.SearchAsync(q);
        return Ok(new SearchResponse { Results = results });
    }
}
