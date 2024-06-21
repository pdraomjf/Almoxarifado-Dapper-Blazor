using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using AlmoxarifadoFront.DTO.Validators;

namespace AlmoxarifadoFront.Components
{
    public class MyInputIntComponent : ComponentBase
    {
        [Parameter]
        public string? Id { get; set; }

        [Parameter]
        public int? Value { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string? ErrorMessage { get; set; }

        [Parameter]
        public IEnumerable<ValidationError>? Errors { get; set; }

        [Parameter]
        public Func<bool>? Validate { get; set; }

        [Parameter]
        public EventCallback<int?> ValueChanged { get; set; }

        protected async Task OnChangeAsync(ChangeEventArgs e)
        {
            int? newValue;

            if (e.Value == null)
                newValue = null;
            else if (!int.TryParse(e.Value.ToString(), out var parsedValue))
                newValue = null;
            else
                newValue = parsedValue;

            Value = newValue;

            await ValueChanged.InvokeAsync(Value);

            if (Validate != null)
                Validate();
        }
    }
}
