namespace Backend.Domain.AppplicationServices.MestresPokemons.Requests;

public class FiltroMestrePokemonRequest
{
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public int IdadeInicio { get; set; } = 0;
    public int IdadeFim { get; set; } = Int32.MaxValue;
}