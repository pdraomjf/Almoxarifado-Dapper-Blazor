using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoModel
{
    public class Produto : IModel
    {
        public string? Id { get; set; }
        public string? Nome { get; set; } = "";
        public int? Quantidade { get; set; }
        public string Tipo { get; set; } = "";
        public string Categoria { get; set; } = "";

    }
}
