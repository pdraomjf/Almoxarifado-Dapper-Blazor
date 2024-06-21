using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AlmoxarifadoFront.DTO.Validators;

namespace AlmoxarifadoFront.DTO
{
    public abstract class ModeloDTO<T> where T : ModeloDTO<T>
    {
        public string? Id { get; set; }

        public IEnumerable<ValidationError>? Errors { get; set; }

        public IEnumerable<ValidationError>? GetErrors<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            if (Errors == null) return Enumerable.Empty<ValidationError>();

            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null) return Enumerable.Empty<ValidationError>();

            var memberName = memberExpression.Member.Name;
            return Errors.Where(error => error.PropertyName.Equals(memberName));
        }

        public abstract void ConfigValidator(out Validator<T> validator, out T obj);

        public bool Validar()
        {
            ConfigValidator(out var validador, out var obj);

            var result = validador.Validate(obj);

            Errors = validador.Errors.ToArray();

            return result;
        }
    }
}
