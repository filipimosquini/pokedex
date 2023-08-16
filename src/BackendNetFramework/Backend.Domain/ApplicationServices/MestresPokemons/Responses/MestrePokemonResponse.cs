using System.Collections.Generic;

namespace Backend.Domain.ApplicationServices.MestresPokemons.Responses;

public class MestrePokemonResponse
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public int Idade { get; set; }
    public List<string> Pokemons { get; set; }
}