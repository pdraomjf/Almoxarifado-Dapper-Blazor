using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using AlmoxarifadoFront.DTO.Validators;


namespace AlmoxarifadoFront.Components
{
    public class MyInputComponent : ComponentBase
    {
        [Parameter]
        public string? Id { get; set; }

        [Parameter]
        public string? Value { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public string? ErrorMessage { get; set; }

        [Parameter]
        public InputType DataType { get; set; } = InputType.Text;

        [Parameter]
        public IEnumerable<ValidationError>? Errors { get; set; }

        [Parameter]
        public Func<bool>? Validate { get; set; }

        [Parameter]
        public EventCallback<string?> ValueChanged { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        protected string GetDataType()
        {
            return DataType.ToString().ToLower();
        }

        protected async Task OnChangeAsync(ChangeEventArgs e)
        {
            var newValue = e.Value as string;

            if (Value != null && Value.Equals(newValue))
                return;

            Value = newValue;

            await ValueChanged.InvokeAsync(Value);

            if (Validate != null)
                Validate();
        }

    }

    public enum InputType
    {
        Text = 0,
        Email = 1,
        Url = 2,
        Tel = 3
    }

}
