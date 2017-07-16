using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MaiorDeIdadeCasoMembro : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cliente = (Cliente)validationContext.ObjectInstance;

            if (cliente.TipoAssinaturaId == TipoAssinatura.Desconhecido
                || cliente.TipoAssinaturaId == TipoAssinatura.Avulso)
            {
                return ValidationResult.Success;
            }

            if (cliente.DataNascimento == null)
            {
                return new ValidationResult("Data de Nascimento obrigatória.");
            }

            var idade = DateTime.Today.Year - cliente.DataNascimento.Value.Year;

            if ((cliente.DataNascimento.Value.Month > DateTime.Now.Month) || (cliente.DataNascimento.Value.Month == DateTime.Now.Month && cliente.DataNascimento.Value.Day > DateTime.Now.Day))
            {
                idade--;
            }

            return (idade >= 18)
                ? ValidationResult.Success
                : new ValidationResult("O cliente deve ser maior de idade para assinar um plano.");

        }
    }
}