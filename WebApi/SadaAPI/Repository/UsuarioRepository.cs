using SadaAPI.DTO;
using SadaAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SadaAPI.Repository
{
    public class UsuarioRepository : BaseRepository    //O repositório do Usuario recebe a herança do repositório do banco
    {

        public Usuario GetOne(int id)   // GetOne  serve pra puxar só um do banco
        {
            return DataModel.Usuario.FirstOrDefault(e => e.Id_Usuario == id);  // Lambda, serve pra puxar o usuário pelo ID

        }


        public List<Usuario> GetAll() // Uma lista que irá receber todos os usuários do banco 
        {
            return DataModel.Usuario.ToList();
        }

        public void Delete(int id) // Método pra excluir usuario
        {
            var usuario = GetOne(id);
            DataModel.Usuario.Remove(usuario);

            DataModel.SaveChanges();  // Salvar no banco
        }

        public void Save(UsuarioDTO entity) // Editar dados no banco
        {

            Usuario usuario = new Usuario
            {
                Nome = entity.Nome,
                Id_Usuario = entity.Id_Usuario,
                Email = entity.Email,
                Senha = entity.Senha,
                DataCadastro = entity.DataCadastro
            };

            DataModel.Entry(usuario).State = entity.Id_Usuario == 0 ?
                EntityState.Added : EntityState.Modified; // vai buscar o usuário pelo id (caso ele exista) e modificar

            DataModel.SaveChanges();

        }

        public Usuario Logar(Login login) // Editar dados no banco
        {

            return DataModel.Usuario.FirstOrDefault(x => x.Email.ToLower() == login.Email.ToLower() &&
            x.Senha.ToLower() == login.Senha.ToLower());
        }



    }
}