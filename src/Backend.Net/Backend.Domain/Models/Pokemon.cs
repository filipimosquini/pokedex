namespace Backend.Domain.Models;

public class Pokemon
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string MestrePokemonId { get; set; }
    public virtual MestrePokemon MestrePokemon { get; set; }
}