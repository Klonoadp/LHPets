using LHPets.Data;
using LHPets.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHPets.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Cliente>> Get()
        {
            return Ok(Banco.Clientes);
        }

        [HttpPost]
        public ActionResult<Cliente> Post(Cliente cliente)
        {
            cliente.Id = Banco.Clientes.Count == 0
                ? 1
                : Banco.Clientes.Max(c => c.Id) + 1;

            Banco.Clientes.Add(cliente);

            return Created($"/api/clientes/{cliente.Id}", cliente);
        }
    }
}