using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using SadaAPI.DTO;
using SadaAPI.Models;
using SadaAPI.Repository;

namespace SadaAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/animal")]
    public class AnimalsController : ApiController
    {
        private AnimalRepository animalRepository = new AnimalRepository();


        // GET: api/Animal
        [HttpGet]
        [Route("buscar-todos")]
        [ResponseType(typeof(Animal))]
        public List<AnimalDTO> GetAnimal()   // buscar informação
        {
            List<AnimalDTO> list = new List<AnimalDTO>();   // lista que recebe os dados do DTO 

            foreach (var item in animalRepository.GetAll()) // chamar todos os Usuário
            {
                AnimalDTO dto = new AnimalDTO();           // instanciando o dto
                dto.Nome = item.Nome;                        // adicionando os dados do usuario no dto 
                dto.Raca = item.Raca;
                dto.Sexo = item.Sexo;
                dto.Tamanho = item.Tamanho;                        // adicionando os dados do usuario no dto 
                dto.Cor = item.Cor;
                dto.DescricaoAnimal = item.DescricaoAnimal;
                list.Add(dto);                               // Adicionar  dto na lista

            }

            return list;                                    // retornar a lista com o dto


        }

        // GET: api/Animal/5
        [HttpGet]
        [Route("busca-por-id/{id:int}")]
        [ResponseType(typeof(Animal))]
        public IHttpActionResult GetAnimal(int id)
        {
            var animal = animalRepository.GetOne(id);


            if (animal== null)
                return BadRequest("Animal não existe.");


            AnimalDTO dto = new AnimalDTO();
            dto.Nome = animal.Nome;
            dto.Raca = animal.Raca;
            dto.Sexo = animal.Sexo;
            dto.Tamanho = animal.Tamanho;
            dto.Cor = animal.Cor;
            dto.DescricaoAnimal = animal.DescricaoAnimal;
            return Ok(dto);

        }

        // PUT: api/Animal/5
        [HttpPut]
        [Route("editar")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnimal(int id, AnimalDTO animal)         // Editar os dados
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != animal.Id_Animal)
            {
                return BadRequest();
            }


            try
            {
                animalRepository.Save(animal);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Animal

        [HttpPost]
        [Route("cadastrar")]
        [ResponseType(typeof(AnimalDTO))]                           // Cadastrar 
        public IHttpActionResult PostAnimal(AnimalDTO animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            animalRepository.Save(animal);

            return Created("DefaultApi", animal);
            // return CreatedAtRoute("DefaultApi", new { id = usuario.Id_Usuario }, usuario);
        }

        // DELETE: api/Animal/5
        [HttpDelete]
        [Route("deletar")]
        [ResponseType(typeof(Animal))]                // Apagar
        public IHttpActionResult DeleteAnimal(int id)
        {
          animalRepository.Delete(id);
            return Ok();
        }


        private bool AnimalExists(int id)
        {
            return animalRepository.GetOne(id) != null;
        }
    }
}