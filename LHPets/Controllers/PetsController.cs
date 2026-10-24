using LHPets.Data;
using LHPets.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHPets.Controllers
{
    [ApiController]
    [Route("api/pets")]
    public class PetsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Pet>> Get()
        {
            return Ok(Banco.Pets);
        }

        [HttpPost]
        public ActionResult<Pet> Post(Pet pet)
        {
            bool clienteExiste = Banco.Clientes
                .Any(cliente => cliente.Id == pet.ClienteId);

            if (!clienteExiste)
            {
                return BadRequest(
                    "O ClienteId informado não corresponde a um cliente cadastrado."
                );
            }

            pet.Id = Banco.Pets.Count == 0
                ? 1
                : Banco.Pets.Max(p => p.Id) + 1;

            Banco.Pets.Add(pet);

            return Created($"/api/pets/{pet.Id}", pet);
        }

        [HttpGet("cliente/{clienteId}")]
        public ActionResult<List<Pet>> GetPorCliente(int clienteId)
        {
            var pets = Banco.Pets
                .Where(pet => pet.ClienteId == clienteId)
                .ToList();

            return Ok(pets);
        }
    }
}