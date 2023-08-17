using Backend.Api.Bases;
using Backend.Application.Configurations;
using Backend.Application.Validators;
using Backend.Domain.ApplicationServices.Pokemons;
using Backend.Domain.ApplicationServices.Pokemons.Requests;
using Backend.Domain.ApplicationServices.Pokemons.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backend.Api.Controllers
{
    public class PokemonController : MainController
    {
        private readonly IPokemonApplicationService _applicationService;
        private readonly CapturarPokemonRequestValidator _capturarPokemonRequestValidator;

        public PokemonController(IPokemonApplicationService applicationService, CapturarPokemonRequestValidator capturarPokemonRequestValidator)
        {
            _applicationService = applicationService;
            _capturarPokemonRequestValidator = capturarPokemonRequestValidator;
        }

        [HttpPost, Route("pokemons")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> CapturarAsync([FromBody] CapturarPokemonRequest request)
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

        [HttpGet, Route("pokemons")]
        [ResponseType(typeof(IEnumerable<PokemonResponse>))]
        public async Task<IHttpActionResult> ListarAsync()
            => Ok(await _applicationService.ListarAsync());

        [HttpGet, Route("pokemons/{id}")]
        [ResponseType(typeof(PokemonResponse))]
        public async Task<IHttpActionResult> ObterAsync(int id)
            => Ok(await _applicationService.ObterAsync(id));
    }
}