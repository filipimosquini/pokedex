using Backend.Application.Configurations.Bases;
using Backend.Domain.AppplicationServices.MestresPokemons.Requests;
using FluentValidation;

namespace Backend.Application.Validators.MestresPokemon;

public class AtualizarMestrePokemonRequestValidator : BaseAbstractValidator<AtualizarMestrePokemonRequest>
{
    public AtualizarMestrePokemonRequestValidator()
    {
        RuleFor(x => x.Id)
            .Must(ValidarStringNulaEVazia).WithMessage("O campo Id é obrigatório")
            .Must(ValidarGuid).WithMessage("O campo Id é inválido");

        RuleFor(x => x.Nome)
            .Must(ValidarStringNulaEVazia).WithMessage("O campo Nome é obrigatório");

        RuleFor(x => x.Idade)
            .GreaterThan(0).WithMessage("O campo Idade deve ser maior que zero");


        RuleFor(x => x.Cpf)
            .Must(ValidarStringNulaEVazia).WithMessage("O campo CPF é obrigatório")
            .IsValidCPF().WithMessage("O campo CPF é inválido");
    }
}