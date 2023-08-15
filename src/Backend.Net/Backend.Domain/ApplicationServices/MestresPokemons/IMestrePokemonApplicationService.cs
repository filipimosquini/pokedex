using Backend.Domain.ApplicationServices.MestresPokemons.Responses;
using Backend.Domain.AppplicationServices.MestresPokemons.Requests;
using Backend.Domain.Bases.ApplicationsServices;

namespace Backend.Domain.ApplicationServices.MestresPokemons;

public interface IMestrePokemonApplicationService
{
    Task<ICustomValidationResult> AdicionarAsync(AdicionarMestrePokemonRequest request);
    Task<ICustomValidationResult> AtualizarAsync(AtualizarMestrePokemonRequest request);
    Task<IEnumerable<MestrePokemonResponse>> ListarAsync(FiltroMestrePokemonRequest request);
    Task<MestrePokemonResponse> ObterAsync(string id);
}