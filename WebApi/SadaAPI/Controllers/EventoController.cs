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
    [RoutePrefix("api/evento")]
    public class EventoController : ApiController
    {
        private EventoRepository eventoRepository = new EventoRepository();


        // GET: api/Evento
        [HttpGet]
        [Route("buscar-todos")]
        [ResponseType(typeof(Evento))]
        public List<EventoDTO> GetEvento()   // buscar informação
        {
            List<EventoDTO> list = new List<EventoDTO>();   // lista que recebe os dados do DTO 

            foreach (var item in eventoRepository.GetAll()) // chamar todos os Usuário
            {
                EventoDTO dto = new EventoDTO();           // instanciando o dto
                dto.Nome = item.Nome;                        // adicionando os dados do usuario no dto 
                dto.DescricaoEvento = item.DescricaoEvento;
                dto.DataInicio = item.DataInicio;
                dto.DataEncerramento =  item.DataEncerramento;                        // adicionando os dados do usuario no dto 
                dto.Local = item.Local;
                dto.ListaDePresenca = item.ListaDePresenca;
                list.Add(dto);                               // Adicionar  dto na lista

            }

            return list;                                    // retornar a lista com o dto


        }

        // GET: api/Evento/5
        [HttpGet]
        [Route("busca-por-id/{id:int}")]
        [ResponseType(typeof(Evento))]
        public IHttpActionResult GetEvento(int id)
        {
            var evento = eventoRepository.GetOne(id);


            if (evento == null)
                return BadRequest("Evento não existe.");


            EventoDTO dto = new EventoDTO();
            dto.Nome = evento.Nome;
            dto.DescricaoEvento = evento.DescricaoEvento;
            dto.DataInicio = evento.DataInicio;
            dto.DataEncerramento = evento.DataEncerramento;
            dto.Local = evento.Local;
            dto.ListaDePresenca = evento.ListaDePresenca;
            return Ok(dto);

        }

        // PUT: api/Evento/5
        [HttpPut]
        [Route("editar")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvento(int id, EventoDTO evento)         // Editar os dados
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evento.Id_Evento)
            {
                return BadRequest();
            }


            try
            {
                eventoRepository.Save(evento);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
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

        // POST: api/Evento

        [HttpPost]
        [Route("cadastrar")]
        [ResponseType(typeof(EventoDTO))]                           // Cadastrar 
        public IHttpActionResult PostEvento(EventoDTO evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            eventoRepository.Save(evento);

            return Created("DefaultApi", evento);
            // return CreatedAtRoute("DefaultApi", new { id = usuario.Id_Usuario }, usuario);
        }

        // DELETE: api/Evento/5
        [HttpDelete]
        [Route("deletar")]
        [ResponseType(typeof(Evento))]                // Apagar
        public IHttpActionResult DeleteEvento(int id)
        {
            eventoRepository.Delete(id);
            return Ok();
        }


        private bool EventoExists(int id)
        {
            return eventoRepository.GetOne(id) != null;
        }
    }
}