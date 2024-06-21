using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmoxarifadoModel;
using FluentValidation;

namespace AlmoxarifadoFront.DTO.Validators
{
    public class ProdutoValidator : Validator<ProdutoDTO>
    {
        public ProdutoValidator()
        {
            AddRule(p => p.Nome).NotEmpty().NotNull().WithMessage("Nome não pode ser nulo ou vazio");
            AddRule(p => p.Nome).MinimumLength(3).WithMessage("Nome deve ter no mínimo 3 caracteres");
            AddRule(p => p.Nome).MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres");
            AddRule(p => p.Categoria).NotEmpty().NotNull().WithMessage("Categoria não pode ser nula ou vazia");
            AddRule(p => p.Categoria).MinimumLength(3).WithMessage("Categoria deve ter no mínimo 3 caracteres");
            AddRule(p => p.Tipo).NotEmpty().NotNull().WithMessage("Tipo não pode ser nula ou vazia");
            AddRule(p => p.Tipo).MinimumLength(3).WithMessage("Tipo deve ter no mínimo 3 caracteres");
            AddRule(p => p.Quantidade).GreaterThanOrEqualTo(0).WithMessage("A quantidade deve ser maior ou igual a 0");
        }
    }

}
