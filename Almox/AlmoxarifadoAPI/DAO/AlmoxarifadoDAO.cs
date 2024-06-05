using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmoxarifadoModel;

namespace AlmoxarifadoAPI.DAO
{
    public class AlmoxarifadoDAO : BaseDAO<Almoxarifado>
    {
        public override string NomeTabela => "almoxarifado";

        public override Mapa[] Mapas => new Mapa[]
        {
            new() { Propriedade = "Id", Campo = "id" },
            new() { Propriedade = "Item", Campo = "item" },
            new() { Propriedade = "Quantidade", Campo = "quantidade" },
            new() { Propriedade = "Categoria", Campo = "categoria" },
        };
    }
}