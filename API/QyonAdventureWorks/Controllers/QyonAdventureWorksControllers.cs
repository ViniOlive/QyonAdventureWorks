using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QyonAdventureWorks.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QyonAdventureWorks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QyonAdventureWorksControllers : Controller
    {

        // POST api/<QyonAdventureWorksControllers>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<QyonAdventureWorksControllers>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QyonAdventureWorksControllers>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    [Route("Api/Competidores")]
    [ApiController]
    public class Competidores : Controller
    {
        private readonly ApplicationDbContext _context;

        public Competidores(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<QyonAdventureWorksControllers>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Obtém todas as tabelas do banco de dados
            var dados = await _context.competidores.ToListAsync();

            return Ok(dados);
        }

        [HttpGet("{ID}")]
        
        public async Task<IActionResult> Get(int id)
        {
            var dados = await _context.competidores.Where(comp => comp.id_competidor == id).ToListAsync();

            return Ok(dados);
        }

        [HttpPut("{ID}")]

        public async Task<ActionResult> Put(int id, [FromBody] competidores competidor)
        {
            var competidor_db = await _context.competidores.FindAsync(id);

            if (!string.IsNullOrEmpty(competidor.nome))
            {
                competidor_db.nome = competidor.nome;
            }

            return Ok(_context.SaveChanges());
        }


    }
}
