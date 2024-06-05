using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmoxarifadoModel
{
    public class Almoxarifado : IModel
    {
        public string? Id { get; set; }
        public string? Item { get; set; }
        public int Quantidade { get; set; }
        public string? Categoria { get; set; }
    }
}