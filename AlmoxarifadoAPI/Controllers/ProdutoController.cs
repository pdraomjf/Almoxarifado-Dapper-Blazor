using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmoxarifadoModel;
using AlmoxarifadoInfra.DAO;
using Microsoft.AspNetCore.Mvc;


namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        public ProdutoController()
        {
            dao = new ProdutoDAO();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetAsync()
        {
            var objetos = await dao.RetornarTodosAsync();

            if (objetos == null)
                return NotFound();

            return Ok(objetos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetId(string id)
        {
            var obj = await dao.RetornarPorIdAsync(id);

            if (obj == null)
                return NotFound();

            return obj;
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostAsync(Produto obj)
        {
            await dao.InserirAsync(obj);

            return CreatedAtAction(
                nameof(GetId),
                new { id = obj.Id },
                obj
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, Produto obj)
        {
            if (id != obj.Id)
                return BadRequest();

            var objOrig = await dao.RetornarPorIdAsync(id);

            if (objOrig == null)
                return NotFound();

            objOrig.Nome = obj.Nome;
            objOrig.Quantidade = obj.Quantidade;
            objOrig.Tipo = obj.Tipo;
            objOrig.Categoria = obj.Categoria;

            await dao.AlterarAsync(obj);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var obj = await dao.RetornarPorIdAsync(id);

            if (obj == null)
                return NotFound();

            await dao.ExcluirAsync(id);

            return NoContent();
        }

        private readonly ProdutoDAO dao;
    }

}
