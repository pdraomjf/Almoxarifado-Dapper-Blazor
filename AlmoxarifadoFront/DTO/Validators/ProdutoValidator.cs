using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmoxarifadoModel;
using FluentValidation;

namespace AlmoxarifadoFront.DTO.Validators
{
    public class ProdutoValidator : Validator<Produto>
    {
        public ProdutoValidator()
        {
            AddRule(p => p.Nome).NotEmpty().NotNull().WithMessage("Nome não pode ser nulo ou vazio");
            AddRule(p => p.Nome).MinimumLength(3).WithMessage("Nome deve ter no mínimo 3 caracteres");
            AddRule(p => p.Nome).MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres");
        }
    }

}
