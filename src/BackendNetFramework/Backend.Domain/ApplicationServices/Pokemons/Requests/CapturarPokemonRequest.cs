namespace Backend.Domain.ApplicationServices.Pokemons.Requests;

public class CapturarPokemonRequest
{
    public int PokemonId { get; set; }
    public string MestrePokemonId { get; set; }
}