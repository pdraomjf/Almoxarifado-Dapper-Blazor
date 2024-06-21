using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using AlmoxarifadoFront.DTO.Validators;


namespace AlmoxarifadoFront.Components
{
    public class MyInputDoubleComponent : ComponentBase
    {
        [Parameter]
        public string? Id { get; set; }

        [Parameter]
        public double Value { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public string? Step { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string? ErrorMessage { get; set; }

        [Parameter]
        public IEnumerable<ValidationError>? Errors { get; set; }

        [Parameter]
        public Func<bool>? Validate { get; set; }

        [Parameter]
        public EventCallback<double> ValueChanged { get; set; }

        protected async Task OnChangeAsync(ChangeEventArgs e)
        {
            double newValue;

            if (e.Value == null)
                newValue = 0;
            else if (!double.TryParse(e.Value.ToString()?.Replace(".", ","), out newValue))
                newValue = 0;

            Value = newValue;

            await ValueChanged.InvokeAsync(Value);

            if (Validate != null)
                Validate();
        }
    }

}
