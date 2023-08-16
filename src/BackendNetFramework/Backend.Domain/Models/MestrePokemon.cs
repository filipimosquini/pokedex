using System.Collections.Generic;
using Backend.Domain.Bases.Models;

namespace Backend.Domain.Models;

public class MestrePokemon : BaseModel
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string CPF { get; set; }

    public virtual ICollection<Pokemon> Pokemons { get; set; }
}