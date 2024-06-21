using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlmoxarifadoModel;

namespace AlmoxarifadoInfra.DAO
{
    public class AlmoxarifadoDAO : BaseDAO<Almoxarifado>
    {
        public override string NomeTabela => "almoxarifado";

        public override Mapa[] Mapas => new Mapa[]
        {
            new() { Propriedade = "Id", Campo = "id" },
            new() { Propriedade = "Empresa", Campo = "empresa" },
            new() { Propriedade = "CNPJ", Campo = "cnpj" }
            
        };

    }
}
