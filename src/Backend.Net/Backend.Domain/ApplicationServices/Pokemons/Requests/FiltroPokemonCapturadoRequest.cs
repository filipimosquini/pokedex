namespace Backend.Domain.ApplicationServices.Pokemons.Requests;

public class FiltroPokemonCapturadoRequest
{
    public string Nome { get; set; } = string.Empty;
    public string MestrePokemon { get; set; } = string.Empty;
}