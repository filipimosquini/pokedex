using Backend.Api.Bases;
using Backend.Domain.ApplicationServices.Pokemons;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("pokemons")]
public class PokemonController : MainController
{
    private readonly IPokemonApplicationService _applicationService;

    public PokemonController(IPokemonApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    [HttpGet]
    public async Task<IActionResult> ListarAsync()
        => Ok(await _applicationService.ListarAsync());

    [HttpGet("{pokemonId}")]
    public async Task<IActionResult> ObterAsync(int pokemonId)
        => Ok(await _applicationService.ObterAsync(pokemonId));
}