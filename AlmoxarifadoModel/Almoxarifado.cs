using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoModel
{
    public class Almoxarifado : IModel
    {
        public string? Id { get; set ; }
        public string Empresa { get; set; } = "";
        public string CNPJ { get; set; } = "";

    }
}
