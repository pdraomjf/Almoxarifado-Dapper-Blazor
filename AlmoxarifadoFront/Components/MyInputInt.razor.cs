//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using AlmoxarifadoFront.DTO.Validators;
//using Microsoft.AspNetCore.Components;

//namespace AlmoxarifadoFront.Components
//{
//    public class MyInputIntComponent : ComponentBase
//    {
//        [Parameter]
//        public string? Id { get; set; }

//        [Parameter]
//        public int Value { get; set; }

//        [Parameter]
//        public string? Title { get; set; }

//        [Parameter]
//        public bool Disabled { get; set; }

//        [Parameter]
//        public string? ErrorMessage { get; set; }

//        [Parameter]
//        public IEnumerable<ValidationError>? Errors { get; set; }

//        [Parameter]
//        public Func<bool>? Validate { get; set; }

//        [Parameter]
//        public EventCallback<int> ValueChanged { get; set; }

//        protected async Task OnChangeAsync(ChangeEventArgs e)
//        {
//            int newValue;

//            if (e.Value == null)
//                newValue = 0;
//            else if (!int.TryParse(e.Value.ToString(), out newValue))
//                newValue = 0;

//            Value = newValue;

//            await ValueChanged.InvokeAsync(Value);

//            if (Validate != null)
//                Validate();
//        }
//    }
//}
