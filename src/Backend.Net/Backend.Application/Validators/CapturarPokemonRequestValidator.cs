using Backend.Application.Configurations.Bases;
using Backend.Domain.ApplicationServices.Pokemons.Requests;
using FluentValidation;

namespace Backend.Application.Validators;

public class CapturarPokemonRequestValidator : BaseAbstractValidator<CapturarPokemonRequest>
{
    public CapturarPokemonRequestValidator()
    {
        RuleFor(x => x.MestrePokemonId)
            .Must(ValidarStringNulaEVazia).WithMessage("O campo Mestre Pokemon Id é obrigatório")
            .Must(ValidarGuid).WithMessage("O campo Mestre Pokemon Id é inválido");

        RuleFor(x => x.PokemonId)
            .GreaterThan(0).WithMessage("O campo Pokemon Id deve ser maior que zero");
    }
}