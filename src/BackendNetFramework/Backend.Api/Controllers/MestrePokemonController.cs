using Backend.Api.Bases;
using Backend.Application.Configurations;
using Backend.Application.Validators;
using Backend.Domain.ApplicationServices.MestresPokemons;
using Backend.Domain.ApplicationServices.MestresPokemons.Responses;
using Backend.Domain.AppplicationServices.MestresPokemons.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Backend.Api.Controllers
{
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
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> AdicionarAsync([FromBody] AdicionarMestrePokemonRequest request)
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
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> AtualizarAsync([FromBody] AtualizarMestrePokemonRequest request)
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
        [ResponseType(typeof(IEnumerable<MestrePokemonResponse>))]
        public async Task<IHttpActionResult> ListarAsync([FromUri] FiltroMestrePokemonRequest request)
        {
            return Ok(await _applicationService.ListarAsync(request));
        }

        [HttpGet]
        [ResponseType(typeof(MestrePokemonResponse))]
        public async Task<IHttpActionResult> OberAsync(string id)
        {
            return Ok(await _applicationService.ObterAsync(id));
        }
    }
}