namespace Backend.Domain.AppplicationServices.MestresPokemons.Requests;

public class AtualizarMestrePokemonRequest
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public int Idade { get; set; }
}