using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AlmoxarifadoAPI.DAO;
using AlmoxarifadoModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlmoxarifadoController : ControllerBase
    {
        private readonly AlmoxarifadoDAO dao;
        public AlmoxarifadoController()
        {
            dao = new AlmoxarifadoDAO();
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Almoxarifado>>> GetAll()
        {
            var obj = await dao.BuscarTodos();

            if (obj == null)
            {
                return NotFound();
            }

            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Almoxarifado>> GetId(string id)
        {
            var obj = await dao.BuscarId(id);

            if (obj == null)
            {
                return NotFound();
            }

            return Ok(obj);
        }

        [HttpPost]
        public async Task<ActionResult<Almoxarifado>> Post(Almoxarifado obj)
        {
            await dao.Inserir(obj);

            return CreatedAtAction(
                nameof(GetId),
                new { id = obj.Id },
                obj
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Almoxarifado obj)
        {
            if (id != obj.Id)
            {
                return BadRequest();
            }

            var objOriginal = await dao.BuscarId(id);

            if (objOriginal == null)
            {
                return NotFound();
            }

            objOriginal.Item = obj.Item;
            objOriginal.Categoria = obj.Categoria;
            objOriginal.Quantidade = obj.Quantidade;

            await dao.Alterar(objOriginal);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var obj = await dao.BuscarId(id);

            if (obj == null)
            {
                return NotFound();
            }

            await dao.Excluir(id);

            return NoContent();
        }
    }
}