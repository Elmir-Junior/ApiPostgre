using ApiRestFul.Data;
using ApiRestFul.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRestFul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly AppDbcontext appDbcontext;

        public ValuesController(AppDbcontext appDbcontext)
        {
            this.appDbcontext = appDbcontext;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return appDbcontext.usuarios.ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            return appDbcontext.usuarios.Find(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Usuario usuario)
        {
            appDbcontext.usuarios.Add(usuario);
            appDbcontext.SaveChanges();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Usuario value)
        {
            appDbcontext.usuarios.Remove(appDbcontext.usuarios.Find(id));
            appDbcontext.usuarios.Add(value);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            appDbcontext.usuarios.Remove(appDbcontext.usuarios.Find(id));
        }
    }
}
