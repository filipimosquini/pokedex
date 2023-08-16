namespace Backend.Domain.ApplicationServices.Pokemons.Responses;

public class PokemonResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<string> Evolucoes { get; set; }
}