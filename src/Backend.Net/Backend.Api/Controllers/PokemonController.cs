using Backend.Api.Bases;
using Backend.Application.Configurations;
using Backend.Application.Validators;
using Backend.Domain.ApplicationServices.Pokemons;
using Backend.Domain.ApplicationServices.Pokemons.Requests;
using Backend.Domain.ApplicationServices.Pokemons.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("pokemons")]
public class PokemonController : MainController
{
    private readonly IPokemonApplicationService _applicationService;
    private readonly CapturarPokemonRequestValidator _capturarPokemonRequestValidator;

    public PokemonController(IPokemonApplicationService applicationService, CapturarPokemonRequestValidator capturarPokemonRequestValidator)
    {
        _applicationService = applicationService;
        _capturarPokemonRequestValidator = capturarPokemonRequestValidator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CapturarAsync([FromBody] CapturarPokemonRequest request)
    {
        if (!ModelState.IsValid)
        {
            return CustomResponseError(ModelState);
        }

        var validateResult = _capturarPokemonRequestValidator.Validate(request);
        if (validateResult.IsValid)
        {
            return CustomResponse((CustomValidationResult)await _applicationService.CapturarAsync(request));
        }

        return CustomResponseError(validateResult);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PokemonResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ListarAsync()
        => Ok(await _applicationService.ListarAsync());

    [HttpGet("capturados")]
    [ProducesResponseType(typeof(IEnumerable<PokemonCapturadoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ListarCapturadosAsync([FromQuery] FiltroPokemonCapturadoRequest request)
        => Ok(await _applicationService.ListarPokemonsCapturadosAsync(request));

    [HttpGet("{pokemonId}")]
    [ProducesResponseType(typeof(PokemonResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ObterAsync(int pokemonId)
        => Ok(await _applicationService.ObterAsync(pokemonId));
}