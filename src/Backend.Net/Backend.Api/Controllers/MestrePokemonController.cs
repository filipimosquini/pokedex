using Backend.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[ApiController]
[Route("mestres")]
public class MestrePokemonController : ControllerBase
{
    
    private readonly IMestrePokemonService _mestrePokemonService;

    public MestrePokemonController(IMestrePokemonService mestrePokemonService)
    {
        _mestrePokemonService = mestrePokemonService;
    }

    [HttpGet]
    public async Task<IActionResult> ListarAsync()
    {
        return Ok(await _mestrePokemonService.ListarAsync());
    }
}