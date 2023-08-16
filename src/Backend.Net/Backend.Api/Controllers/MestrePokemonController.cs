using Backend.Api.Bases;
using Backend.Application.Configurations;
using Backend.Application.Validators;
using Backend.Domain.ApplicationServices.MestresPokemons;
using Backend.Domain.ApplicationServices.MestresPokemons.Responses;
using Backend.Domain.AppplicationServices.MestresPokemons.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[ApiController]
[Route("mestres-pokemons")]
public class MestrePokemonController : MainController
{
    private readonly IMestrePokemonApplicationService _applicationService;
    private readonly AdicionarMestrePokemonRequestValidator _adicionarMestrePokemonRequestValidator;
    private readonly AtualizarMestrePokemonRequestValidator _atualizarMestrePokemonRequestValidator;

    public MestrePokemonController(IMestrePokemonApplicationService applicationService, 
        AdicionarMestrePokemonRequestValidator adicionarMestrePokemonRequestValidator, 
        AtualizarMestrePokemonRequestValidator atualizarMestrePokemonRequestValidator)
    {
        _applicationService = applicationService;
        _adicionarMestrePokemonRequestValidator = adicionarMestrePokemonRequestValidator;
        _atualizarMestrePokemonRequestValidator = atualizarMestrePokemonRequestValidator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AdicionarAsync([FromBody] AdicionarMestrePokemonRequest request)
    {
        if (!ModelState.IsValid)
        {
            return CustomResponseError(ModelState);
        } 

        var validateResult = _adicionarMestrePokemonRequestValidator.Validate(request);
        if (validateResult.IsValid)
        {
            return CustomResponse((CustomValidationResult)await _applicationService.AdicionarAsync(request));
        }

        return CustomResponseError(validateResult);
    }

    [HttpPut]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AtualizarAsync([FromBody] AtualizarMestrePokemonRequest request)
    {
        if (!ModelState.IsValid)
        {
            return CustomResponseError(ModelState);
        }

        var validateResult = _atualizarMestrePokemonRequestValidator.Validate(request);
        if (validateResult.IsValid)
        {
            return CustomResponse((CustomValidationResult)await _applicationService.AtualizarAsync(request));
        }

        return CustomResponseError(validateResult);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<MestrePokemonResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ListarAsync([FromQuery] FiltroMestrePokemonRequest request)
    {
        return Ok(await _applicationService.ListarAsync(request));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(MestrePokemonResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> OberAsync(string id)
    {
        return Ok(await _applicationService.ObterAsync(id));
    }
}