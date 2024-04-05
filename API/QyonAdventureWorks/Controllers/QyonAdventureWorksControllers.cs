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
    [Route("/QyonAdventureWorks/Api/Competidores")]
    [ApiController]
    public class Competidores : Controller
    {
        private readonly ApplicationDbContext _context;

        public Competidores(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Post([FromBody] competidores body)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var competidor = new competidores
                    {
                        nome = body.nome,
                        sexo = body.sexo,
                        temperaturamediacorpo = body.altura,
                        peso = body.peso,
                        altura = body.altura
                    };

                    _context.competidores.Add(competidor);
                    _context.SaveChanges();

                    return Ok("Dados inseridos com sucesso!");
                }
                catch (Exception ex)
                {

                    return StatusCode(500, $"Erro ao inserir dados: {ex.Message}");
                }

            }
            else
            {
                return BadRequest(ModelState);
            }


        }

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

        public async Task<ActionResult> Put(int id, [FromBody] Competidores_UP body)
        {
            var competidor_db = await _context.competidores.FindAsync(id);

            competidor_db.nome = !string.IsNullOrEmpty(body.nome) ? body.nome : competidor_db.nome;
            competidor_db.sexo = !string.IsNullOrEmpty(body.sexo) ? body.sexo : competidor_db.sexo;
            competidor_db.temperaturamediacorpo = body.temperaturamediacorpo > 0 ? body.temperaturamediacorpo : competidor_db.temperaturamediacorpo;
            competidor_db.peso = body.peso > 0 ? body.peso : competidor_db.peso;
            competidor_db.altura = body.altura > 0 ? body.altura : competidor_db.altura;

            try
            {
                _context.SaveChanges();

                return Ok("Dados do corredor(a) atualizados com sucesso!");
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Erro ao deletar pista: {ex.Message}");
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var corredor = _context.competidores.FirstOrDefault(c => c.id_competidor == id);

                if (corredor == null)
                {
                    return NotFound("Corredor não encontrado.");
                }

                _context.competidores.Remove(corredor);
                _context.SaveChanges();

                return Ok("Corredor deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao deletar corredor: {ex.Message}");
            }
        }
    }

    [Route("/QyonAdventureWorks/Api/Pistas")]
    [ApiController]

    public class Pistas : Controller
    {
        private readonly ApplicationDbContext _context;

        public Pistas(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]

        public IActionResult Post([FromBody] pistacorrida body)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var pista = new pistacorrida
                    {
                        descricao = body.descricao
                    };

                    _context.pistacorrida.Add(pista);
                    _context.SaveChanges();

                    return Ok("Dados inseridos com sucesso!");
                }
                catch (Exception ex)
                {

                    return StatusCode(500, $"Erro ao inserir dados: {ex.Message}");
                }

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Obtém todas as tabelas do banco de dados
            var dados = await _context.pistacorrida.ToListAsync();

            return Ok(dados);
        }

        [HttpGet("{ID}")]

        public async Task<IActionResult> Get(int id)
        {
            var dados = await _context.pistacorrida.Where(comp => comp.id_pista == id).ToListAsync();

            return Ok(dados);
        }

        [HttpPut("{ID}")]

        public async Task<ActionResult> Put(int id, [FromBody] pistacorrida body)
        {
            var pistacorrida = await _context.pistacorrida.FindAsync(id);

            pistacorrida.descricao = !string.IsNullOrEmpty(body.descricao) ? body.descricao : pistacorrida.descricao;

            try
            {
                _context.SaveChanges();

                return Ok("Pista atualizada com sucesso!");
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Erro ao deletar pista: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var pista = _context.pistacorrida.FirstOrDefault(c => c.id_pista == id);

                if (pista == null)
                {
                    return NotFound("Pista não encontrado.");
                }

                _context.pistacorrida.Remove(pista);
                _context.SaveChanges();

                return Ok("Pista deletada com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao deletar pista: {ex.Message}");
            }
        }
    }

    [Route("/QyonAdventureWorks/Api/HistoricoDeCorrida")]
    [ApiController]

    public class HistoricoDeCorrida : Controller
    {
        private readonly ApplicationDbContext _context;

        public HistoricoDeCorrida(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionarHistoricoCorrida([FromBody] historicocorrida body)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var historico = new historicocorrida
                    {
                        competidorid = body.competidorid,
                        pistacorridaid = body.pistacorridaid,
                        datacorrida = body.datacorrida,
                        tempogasto = body.tempogasto
                    };
                    _context.historicocorrida.Add(historico);
                    _context.SaveChanges();

                    return Ok("Histórico de corrida adicionado com sucesso!");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Erro ao adicionar histórico de corrida: {ex.Message}");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }


        }

        [HttpPut("{ID}")]

        public IActionResult Put(int id, [FromBody] HistoricoCorrida_UP body)
        {
            var historico = _context.historicocorrida.FirstOrDefault(h => h.id_historico == id);

            historico.competidorid = body.competidorid > 0 ? body.competidorid : historico.competidorid;
            historico.pistacorridaid = body.pistacorridaid > 0 ? body.pistacorridaid : historico.pistacorridaid;
            historico.datacorrida = body.datacorrida == null || body.datacorrida == DateTime.MinValue ? historico.datacorrida : body.datacorrida;
            historico.tempogasto = body.tempogasto > 0 ? body.tempogasto : historico.tempogasto;

            try
            {
                _context.SaveChanges();

                return Ok("Histórico atualizado com sucesso!");
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Erro ao atualizar histórico: {ex.Message}");
            }
        }
    }

    [Route("/QyonAdventureWorks/Api/Pistas/Pistas-Utilizadas")]
    [ApiController]
    public class PistasUtilizadas : Controller
    {
        private readonly ApplicationDbContext _context;

        public PistasUtilizadas(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPistasUtilizadas()
        {
            var pistasUtilizadas = _context.historicocorrida
                                            .Join(_context.pistacorrida,
                                                  hist => hist.pistacorridaid,
                                                  pista => pista.id_pista,
                                                  (hist, pista) => pista.descricao)
                                            .Distinct()
                                            .ToList();

            try
            {
                return Ok(pistasUtilizadas);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Erro ao verificar as pistas que foram utilizadas: {ex.Message}");
            }
        }
    }

    [ApiController]
    [Route("/QyonAdventureWorks/Api/Competidor/Tempo-Medio-Gasto")]
    public class TempoMedioCompetidor : Controller
    {
        private readonly ApplicationDbContext _context;

        public TempoMedioCompetidor(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCompetidoresComTempoMedio()
        {
            var competidoresComTempoMedio = _context.competidores
                        .ToList()
                        .Select(competidor => new
                        {
                            Id = competidor.id_competidor,
                            Nome = competidor.nome,
                            TempoMedio = _context.historicocorrida
                                .Where(hist => hist.competidorid == competidor.id_competidor && hist.tempogasto != null)
                                .AsEnumerable()
                                .Select(hist => (double?)hist.tempogasto)
                                .DefaultIfEmpty()
                                .Average()
                        })
                        .Where(item => item.TempoMedio != null)
                        .ToList();


            try
            {
                return Ok(competidoresComTempoMedio);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Erro ao verificar o tempo médio gasto dos competidores: {ex.Message}");
            }

        }
    }

    [ApiController]
    [Route("/QyonAdventureWorks/Api/Competidor-nao-correu/")]
    public class CompetidorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompetidorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCompetidoresSemCorrida()
        {
            var competidoresSemCorrida = _context.competidores
                                                  .Where(competidor => !_context.historicocorrida.Any(hist => hist.competidorid == competidor.id_competidor))
                                                  .ToList();

            
            try
            {
                return Ok(competidoresSemCorrida);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Erro ao verificar os competidores que não realizaram nenhuma corrida: {ex.Message}");
            }
        }
    }
}
