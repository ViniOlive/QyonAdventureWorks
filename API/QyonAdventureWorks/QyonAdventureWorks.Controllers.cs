using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QyonAdventureWorks.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QyonAdventureWorks
{
    [Route("api/[controller]")]
    [ApiController]
    public class QyonAdventureWorks : ControllerBase
    {

        // GET: api/competidores/5
        [HttpGet("{id}")]
        public ActionResult<Competidores> GetCompetidor(int id)
        {

            Competidores comp = new Competidores();

            comp.Id = 1;
            comp.Nome = "Vinicius";
            comp.Peso = 83;
            comp.Altura = 191;
            comp.Sexo = "M";
            comp.TemperaturaMediaCorpo = 38;

            return comp;
            
        }
    }
}
