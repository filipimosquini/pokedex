using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Backend.Application.Configurations;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Backend.Api.Bases
{
    public class MainController : ApiController
    {
        protected ICollection<string> Erros = new List<string>();

        protected IHttpActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(JsonConvert.SerializeObject(new 
            {
                success = false,
                errors = Erros.ToArray()
            }));
        }

        protected IHttpActionResult CustomResponse(CustomValidationResult customValidationResult)
        {
            if (customValidationResult.HasErrors())
            {
                AdicionarErros(customValidationResult);
                return CustomResponse();
            }

            return CustomResponse(customValidationResult?.Data);
        }

        protected IHttpActionResult CustomResponseError(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) AdicionarErros(modelState);
            return CustomResponse();
        }

        protected IHttpActionResult CustomResponseError(ValidationResult validationResult)
        {
            AdicionarErros(validationResult);
            return CustomResponse();
        }

        private bool OperacaoValida()
        {
            return !Erros.Any();
        }

        private void AdicionarErroProcessamento(string erro)
        {
            Erros.Add(erro);
        }

        private void AdicionarErros(CustomValidationResult validationResult)
        {
            var erros = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

            foreach (var erro in erros)
            {
                AdicionarErroProcessamento(erro);
            }
        }

        private void AdicionarErros(ValidationResult validationResult)
        {
            var erros = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

            foreach (var erro in erros)
            {
                AdicionarErroProcessamento(erro);
            }
        }

        private void AdicionarErros(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                AdicionarErroProcessamento(errorMsg);
            }
        }
    }
}