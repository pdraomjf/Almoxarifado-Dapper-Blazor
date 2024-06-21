using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using AlmoxarifadoModel;

namespace AlmoxarifadoFront.DTO.Validators
{
    public class AlmoxarifadoValidator : Validator<AlmoxarifadoDTO>
    {
        public AlmoxarifadoValidator()
        {
            AddRule(p => p.Empresa).NotEmpty().NotNull().WithMessage("Empresa não pode ser nulo ou vazio");
            AddRule(p => p.Empresa).MinimumLength(1).WithMessage("Empresa deve ter pelo menos 1 caractere");
            AddRule(p => p.CNPJ).MinimumLength(1).MaximumLength(15).WithMessage("CNPJ deve ter 14 caracteres");
        }
    }

}
