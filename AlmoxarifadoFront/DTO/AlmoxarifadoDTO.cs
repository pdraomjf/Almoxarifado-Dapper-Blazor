using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmoxarifadoFront.DTO.Validators;

namespace AlmoxarifadoFront.DTO
{
    public class AlmoxarifadoDTO : ModeloDTO<AlmoxarifadoDTO>
    {
        public string Empresa { get; set; } = "";
        public string CNPJ { get; set; } = "";
        public override void ConfigValidator(out Validator<AlmoxarifadoDTO> validator, out AlmoxarifadoDTO obj)
        {
            validator = new AlmoxarifadoValidator();
            obj = this;
        }
    }
}
