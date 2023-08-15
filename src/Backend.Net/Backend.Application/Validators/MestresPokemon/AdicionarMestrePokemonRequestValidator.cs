using Backend.Application.Configurations.Bases;
using Backend.Domain.AppplicationServices.MestresPokemons.Requests;
using FluentValidation;

namespace Backend.Application.Validators.MestresPokemon;

public class AdicionarMestrePokemonRequestValidator : BaseAbstractValidator<AdicionarMestrePokemonRequest>
{
    public AdicionarMestrePokemonRequestValidator()
    {
        RuleFor(x => x.Nome)
            .Must(ValidarStringNulaEVazia).WithMessage("O campo Nome é obrigatório");

        RuleFor(x => x.Idade)
            .GreaterThan(0).WithMessage("O campo Idade deve ser maior que zero");


        RuleFor(x => x.Cpf)
            .Must(ValidarStringNulaEVazia).WithMessage("O campo CPF é obrigatório")
            .IsValidCPF().WithMessage("O campo CPF é inválido");
    }
}