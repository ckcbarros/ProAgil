using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.API.Data;
using ProAgil.API.Model;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public DataContext _context { get; }
        public ValuesController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _context.Eventos.ToListAsync();

                return Ok(results);    
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao consultar banco de dados");
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> Get(int id)
        {
            try
            {
                var result = await _context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);
                
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao consultar banco de dados");
            }
            
        }
        // GET api/values
/*         [HttpGet]
        public ActionResult<IEnumerable<Evento>> Get()
        {
            return new Evento[] {
                new Evento()
                {
                    EventoId=1,
                    Tema = "Angular",
                    Local = "Belo Horizonte",
                    Lote = "1 lote",
                    QtdPessoas=250,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
                },
                new Evento()
                {
                    EventoId=2,
                    Tema = ".NET",
                    Local = "São Paulo",
                    Lote = "2 lote",
                    QtdPessoas=350,
                    DataEvento = DateTime.Now.AddDays(4).ToString("dd/MM/yyyy")
                }

            };
        }
 */
        // GET api/values/5
        /* [HttpGet("{id}")]
        public ActionResult<Evento> Get(int id)
        {
            return new Evento[] {
                new Evento()
                {
                    EventoId=1,
                    Tema = "Angular",
                    Local = "Belo Horizonte",
                    Lote = "1 lote",
                    QtdPessoas=250,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
                },
                new Evento()
                {
                    EventoId=2,
                    Tema = ".NET",
                    Local = "São Paulo",
                    Lote = "2 lote",
                    QtdPessoas=350,
                    DataEvento = DateTime.Now.AddDays(4).ToString("dd/MM/yyyy")
                }

            }.FirstOrDefault(x => x.EventoId == id);
        } */

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
