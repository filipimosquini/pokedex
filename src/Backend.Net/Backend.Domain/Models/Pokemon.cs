using Backend.Domain.Bases.Models;

namespace Backend.Domain.Models;

public class Pokemon : BaseModel
{
    public virtual MestrePokemon MestrePokemon { get; set; }
}