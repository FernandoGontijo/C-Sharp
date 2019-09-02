using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SadaAPI.Models;
using SadaAPI.Repository;
using SadaAPI.DTO;
using System.Web.Http.Cors;

namespace SadaAPI.Controllers
{



    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/usuario")]
    public class UsuariosController : ApiController
    {

        private UsuarioRepository usuarioRepository = new UsuarioRepository();


        // GET: api/Usuarios
        [HttpGet]
        [Route("buscar-todos")]
        [ResponseType(typeof(Usuario))]
        public List<UsuarioDTO> GetUsuario()   // buscar informação
        {
            List<UsuarioDTO> list = new List<UsuarioDTO>();   // lista que recebe os dados do DTO 
            
            foreach (var item in usuarioRepository.GetAll()) // chamar todos os Usuário
            {
                UsuarioDTO dto = new UsuarioDTO();           // instanciando o dto
                dto.Nome = item.Nome;                        // adicionando os dados do usuario no dto 
                dto.Senha = item.Senha;
                dto.Email = item.Email;
                list.Add(dto);                               // Adicionar  dto na lista
                
            }

            return list;                                    // retornar a lista com o dto


        }

        // GET: api/Usuarios/5
        [HttpGet]
        [Route("busca-por-id/{id:int}")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuario(int id)
        {
            var usuario = usuarioRepository.GetOne(id);


            if (usuario == null)
                return BadRequest("Usuário não existe.");


            UsuarioDTO dto = new UsuarioDTO();
            dto.Nome = usuario.Nome;
            dto.Senha = usuario.Senha;
            dto.Email = usuario.Email;
            
            return Ok(dto);

        }

        // PUT: api/Usuarios/5
        [HttpPut]
        [Route("editar")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario(int id, UsuarioDTO usuario)         // Editar os dados
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.Id_Usuario)
            {
                return BadRequest();
            }

        
            try
            {
                usuarioRepository.Save(usuario);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios

        [HttpPost]
        [Route("cadastrar")]
        [ResponseType(typeof(UsuarioDTO))]                           // Cadastrar 
        public IHttpActionResult PostUsuario(UsuarioDTO usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            usuarioRepository.Save(usuario);

            return Created("DefaultApi", usuario);
           // return CreatedAtRoute("DefaultApi", new { id = usuario.Id_Usuario }, usuario);
        }


        [HttpPost]
        [Route("login")]
        public IHttpActionResult PostUsuario(Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var usuarioLogado = usuarioRepository.Logar(login);

            if (usuarioLogado == null)
                return BadRequest("Email ou senha Incorretos");

            return Ok(usuarioLogado);
            // return CreatedAtRoute("DefaultApi", new { id = usuario.Id_Usuario }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete]
        [Route("deletar")]
        [ResponseType(typeof(Usuario))]                // Apagar
        public IHttpActionResult DeleteUsuario(int id)
        {
            usuarioRepository.Delete(id);
            return Ok();
        }


        private bool UsuarioExists(int id)
        {
            return usuarioRepository.GetOne(id) != null;
        }
    }
}