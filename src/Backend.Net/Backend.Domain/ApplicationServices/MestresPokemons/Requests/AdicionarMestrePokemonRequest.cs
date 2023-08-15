namespace Backend.Domain.AppplicationServices.MestresPokemons.Requests;

public class AdicionarMestrePokemonRequest
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public int Idade { get; set; }
}