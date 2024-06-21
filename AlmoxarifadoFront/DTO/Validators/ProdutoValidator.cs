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
            AddRule(p => p.Nome).NotEmpty().WithMessage("O Nome é obrigatório.");
            AddRule(p => p.Categoria).NotEmpty().WithMessage("A Categoria é obrigatória.");
            AddRule(p => p.Tipo).NotEmpty().WithMessage("O Tipo é obrigatório.");
            AddRule(p => p.Quantidade).GreaterThan(0).WithMessage("A Quantidade deve ser maior que zero.");
        }
    }

}
