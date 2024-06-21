using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlmoxarifadoModel;

namespace AlmoxarifadoInfra.DAO
{
    public class ProdutoDAO : BaseDAO<Produto>
    {
        public override string NomeTabela => "produto";

        public override Mapa[] Mapas => new Mapa[]
        {
            new() { Propriedade = "Id", Campo = "id" },
            new() { Propriedade = "Nome", Campo = "nome" },
            new() { Propriedade = "Quantidade", Campo = "quantidade" },
            new() { Propriedade = "Tipo", Campo = "tipo" },
            new() { Propriedade = "Categoria", Campo = "categoria" }

        };
    }
}
