using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SadaAPI.DTO
{
    public class UsuarioDTO
    {

        public int Id_Usuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}