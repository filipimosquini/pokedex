using Backend.Domain.Bases.Models;

namespace Backend.Domain.Models;

public class Pokemon : BaseModel
{
    public int PokemonId { get; set; }
    public string Nome { get; set; }
    public string MestrePokemonId { get; set; }
    public virtual MestrePokemon MestrePokemon { get; set; }
}